using JwtAuthLibrary;
using LuegoPago.Models;
using LuegoPago.Data;
using LuegoPago.Helpers;
using LuegoPago.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using ExceptionNotification;

namespace LuegoPago.Controllers.Authentication
{
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly Utilidades _utilidades;
        private readonly JwtAuthManager _jwtAuthManager;
        private readonly SlackExceptionNotifier _slackNotifier; // Inyectar SlackExceptionNotifier

        public AuthController(BaseContext context, Utilidades utilidades, JwtAuthManager jwtAuthManager, SlackExceptionNotifier slackNotifier)
        {
            _context = context;
            _utilidades = utilidades;
            _jwtAuthManager = jwtAuthManager;
            _slackNotifier = slackNotifier; // Inyectar SlackExceptionNotifier
        }

        // Endpoint para registrar un nuevo usuario.
        [HttpPost]
        [Route("api/registration")]
        public async Task<IActionResult> Registrarse(Usuario objeto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var modeloUsuario = new Usuario
                {
                    Nombre = objeto.Nombre,
                    Email = objeto.Email,
                    Password = _utilidades.EncriptarSHA256(objeto.Password),
                    Documento = objeto.Documento,
                    IdTipoDocumento = objeto.IdTipoDocumento,
                    IdRol = objeto.IdRol
                };

                await _context.Usuarios.AddAsync(modeloUsuario);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = modeloUsuario.Id != 0 });
            }
            catch (Exception ex)
            {
                // Notificar excepción a Slack
                await _slackNotifier.NotifyAsync(ex, "Error al registrar usuario");

                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno al registrar usuario");
            }
        }

        // Endpoint para autenticar un usuario y generar un token JWT.
        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login(UsuarioLogin objeto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var usuarioEncontrado = await _context.Usuarios
                    .FirstOrDefaultAsync(u => u.Email == objeto.Email);

                // Verificar si el usuario fue encontrado y si la contraseña es correcta
                if (usuarioEncontrado == null || !_utilidades.VerificarSHA256(objeto.Password, usuarioEncontrado.Password))
                {
                    // Lanzar una excepción específica si el usuario no existe o la contraseña es incorrecta
                    throw new InvalidCredentialsException("Usuario o contraseña incorrectos");
                }

                // Generar token JWT para el usuario válido
                var token = _jwtAuthManager.GenerateToken(usuarioEncontrado.Id.ToString(), usuarioEncontrado.Email);
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = token });
            }
            catch (InvalidCredentialsException ex)
            {
                // Notificar excepción específica a Slack
                await _slackNotifier.NotifyAsync(ex, "Intento de inicio de sesión fallido");

                // Manejar la excepción específica
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
            catch (Exception ex)
            {
                // Notificar excepción a Slack
                await _slackNotifier.NotifyAsync(ex, "Error al autenticar usuario");

                // Manejar la excepción general
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno al autenticar usuario");
            }
        }
    }
}

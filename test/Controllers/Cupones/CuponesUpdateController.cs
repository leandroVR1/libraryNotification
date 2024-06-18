using Microsoft.AspNetCore.Mvc;
using LuegoPago.Models;
using LuegoPago.Services;
using ExceptionNotification; 

namespace LuegoPago.Controllers.Cupones
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponUpdateController : ControllerBase
    {
        private readonly ICuponRepository _cuponRepository;
        private readonly SlackExceptionNotifier _slackNotifier; // Inyectar SlackExceptionNotifier

        public CuponUpdateController(ICuponRepository cuponRepository, SlackExceptionNotifier slackNotifier)
        {
            _cuponRepository = cuponRepository;
            _slackNotifier = slackNotifier; // Inyectar SlackExceptionNotifier
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cupon cupon)
        {
            try
            {
                var cuponExistente = _cuponRepository.GetById(id);
                if (cuponExistente == null)
                {
                    return NotFound("Cupón no encontrado"); // Retorna 404 si el cupón no se encuentra
                }

                // Actualizar propiedades del cupón existente con las nuevas propiedades recibidas en cupon
                cuponExistente.Nombre = cupon.Nombre;
                // cuponExistente.Descripcion = cupon.Descripcion;
                // cuponExistente.RegistroFechas.FechaCreacion = cupon.RegistroFechas.FechaCreacion;
                // cuponExistente.RegistroFechas.FechaExpiracion = cupon.RegistroFechas.FechaExpiracion;
                // cuponExistente.ValorDescuento = cupon.ValorDescuento;
                // cuponExistente.Usabilidad = cupon.Usabilidad;
                // cuponExistente.Estado = cupon.Estado;

                _cuponRepository.Update(cuponExistente);

                return Ok("Cupón actualizado"); // Retorna 200 si la actualización fue exitosa
            }
            catch (NullReferenceException ex)
            {
                // Notificar excepción a Slack
                _slackNotifier.NotifyAsync(ex, "Cupón no encontrado en la base de datos");

                return NotFound("Cupón no encontrado en la base de datos"); // Retorna 404 si no se encuentra el cupón
            }
            catch (Exception ex)
            {
                // Notificar excepción a Slack
                _slackNotifier.NotifyAsync(ex, "Error al actualizar cupón");

                return StatusCode(500, "Error interno al actualizar cupón"); // Retorna 500 si hay un error interno
            }
        }
    }
}

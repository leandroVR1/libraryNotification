using Microsoft.AspNetCore.Mvc;
using LuegoPago.Services;
using LuegoPago.Models;
using ExceptionNotification;

namespace LuegoPago.Controllers
{
    [ApiController]
    public class CuponesController : ControllerBase
    {
        private readonly ICuponRepository _cuponRepository;
        private readonly SlackExceptionNotifier _slackNotifier; // Inyectar SlackExceptionNotifier

        public CuponesController(ICuponRepository cuponRepository, SlackExceptionNotifier slackNotifier)
        {
            _cuponRepository = cuponRepository;
            _slackNotifier = slackNotifier; // Inyectar SlackExceptionNotifier
        }

        [HttpGet]
        [Route("api/cupones")]
        public IEnumerable<Cupon> GetCupones()
        {
            return _cuponRepository.GetAll();
        }
        
        [HttpGet]
        [Route("api/cupones/{id}")]
        public IActionResult Details(int id)
        {
            try
            {
                var cupon = _cuponRepository.GetById(id);
                if (cupon == null)
                {
                    // Notificar excepción a Slack
                    _slackNotifier.NotifyAsync(new Exception($"Cupón con ID {id} no encontrado en la base de datos"), $"Cupón con ID {id} no encontrado en la base de datos");

                    return NotFound($"Cupón con ID {id} no encontrado en la base de datos"); // Retorna 404 si no se encuentra el cupón
                }

                return Ok(cupon); // Retorna 200 con el cupón encontrado
            }
            catch (Exception ex)
            {
                // Notificar excepción a Slack
                _slackNotifier.NotifyAsync(ex, "Error al obtener detalles del cupón");

                return StatusCode(500, "Error interno al obtener detalles del cupón"); // Retorna 500 si hay un error interno
            }
        }
    }
}

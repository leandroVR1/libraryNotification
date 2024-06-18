using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LuegoPago.Models;
using LuegoPago.Services;

namespace LuegoPago.Controllers.Cupones
{
    public class CuponCreateController : ControllerBase
    {
        private readonly ICuponRepository _cuponRepository;
        public CuponCreateController(ICuponRepository cuponRepository)
        {
            _cuponRepository = cuponRepository;
        }
        [HttpPost]
        [Route("api/cupones")]
        public IActionResult Create([FromBody] Cupon cupon)
        {
            _cuponRepository.Add(cupon);
            return Ok();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LuegoPago.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace LuegoPago.Controllers.Cupones
{
    public class CuponDeleteController : ControllerBase
    {
        private readonly ICuponRepository _cuponRepository;

        public CuponDeleteController(ICuponRepository cuponRepository)
        {
            _cuponRepository = cuponRepository;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cuponRepository.Remove(id);
            return Ok();
        }
    }
}

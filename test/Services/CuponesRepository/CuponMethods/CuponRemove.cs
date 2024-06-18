using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuegoPago.Data;
using LuegoPago.Models;

namespace LuegoPago.Services.CuponesRepository.CuponMethods
{
    public class CuponRemove
    {
        private readonly BaseContext _context;
        public CuponRemove(BaseContext context){
            _context = context;
        }
        
        public void Remove(int Id)
        {
            var cupon = _context.Cupones.Find(Id);
            _context.Cupones.Remove(cupon!);
            _context.SaveChanges();
        }
    }
}
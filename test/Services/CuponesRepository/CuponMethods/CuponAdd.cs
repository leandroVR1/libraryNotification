using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuegoPago.Data;
using LuegoPago.Models;


namespace LuegoPago.Services.CuponesRepository.CuponMethods
{
    public class CuponAdd
    {
        private readonly BaseContext _context;
        public CuponAdd(BaseContext context){
            _context = context;
        }
        
        public void Add(Cupon cupon)
        {
            _context.Cupones.Add(cupon);
            Console.WriteLine($"Estoy cupon {cupon.Nombre}");
            _context.SaveChanges();
        }
    }
}
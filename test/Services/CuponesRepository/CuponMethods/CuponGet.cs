using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuegoPago.Data;
using LuegoPago.Models;

namespace LuegoPago.Services.CuponesRepository.CuponMethods
{
    public class CuponGet
    {
        private readonly BaseContext _context;
        public CuponGet(BaseContext context){
            _context = context;
        }
        public IEnumerable<Cupon> GetAll()
        {
            return _context.Cupones.ToList();
        }

        public Cupon GetById(int Id)
        {
            // return _context.Cupones.Find(Id)!;
            return _context.Cupones.Find(Id)!;
        }
    }
}
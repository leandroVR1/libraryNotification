using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuegoPago.Data;
using LuegoPago.Models;
using LuegoPago.Services.CuponesRepository.CuponMethods;

namespace LuegoPago.Services.CuponesRepository
{
    public class CuponRepository : ICuponRepository
    {
        private readonly BaseContext _context;
        public CuponRepository(BaseContext context){
            _context = context;

        }
        
        public void Add(Cupon cupon)
        {
            CuponAdd add = new CuponAdd(_context);
            add.Add(cupon);
        }

        public IEnumerable<Cupon> GetAll()
        {
            CuponGet add = new CuponGet(_context);
            return add.GetAll();
        }

        public Cupon GetById(int Id)
        {
            CuponGet add = new CuponGet(_context);
            return add.GetById(Id);
        }

        public void Remove(int Id)
        {
            CuponRemove remove = new CuponRemove(_context);
            remove.Remove(Id);
        }

        public void Update(Cupon cupon)
        {
            _context.Cupones.Update(cupon);
            _context.SaveChanges();
        }
    }

}
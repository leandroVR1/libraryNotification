using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuegoPago.Models;

namespace LuegoPago.Services
{
    public interface ICuponRepository
    {
        IEnumerable<Cupon> GetAll();
        Cupon GetById(int Id);
        void Add(Cupon cupon);
        void Remove(int Id);
        void Update(Cupon cupon);
    }
}
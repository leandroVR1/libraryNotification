using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuegoPago.Models;

namespace LuegoPago.Services.MarcasRepository
{
    public interface IMarcaRepository
    {
        IEnumerable<Marca> GetAll();
        Marca GetById(int Id);
        void Add(Marca marca);
        void Remove(int Id);
        void Update(Marca marca);
    }
}
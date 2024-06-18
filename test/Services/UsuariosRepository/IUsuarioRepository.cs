using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuegoPago.Models;

namespace LuegoPago.Services.UsuariosRepository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int Id);
        void Add(Usuario usuario);
        void Remove(int Id);
        void Update(Usuario usuario);
    }
}
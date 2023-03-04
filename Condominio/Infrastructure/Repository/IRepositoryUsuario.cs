using Infraestructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryUsuario
    {
        Usuario GetUsuario(string email, string password);

        IEnumerable<Usuario> GetUsuarios();

        Usuario GetUsuarioByID(int id);
        Usuario Save(Usuario usuario);
    }
}

using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesUsuario
    {
        Usuario GetUsuario(string email, string password);
        Usuario GetUsuarioByID(int id);
        Usuario Save(Usuario usuario);
        IEnumerable<Usuario> GetUsuarios();
    }
}

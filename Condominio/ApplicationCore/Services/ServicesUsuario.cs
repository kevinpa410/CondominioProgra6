using ApplicationCore.Utils;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesUsuario : IServicesUsuario
    {
        public Usuario GetUsuario(string email, string password)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            // Encriptar el password para poder compararlo

            string cryptPassword = Cryptography.EncrypthAES(password);

            return repository.GetUsuario(email, cryptPassword);
        }

        public Usuario GetUsuarioByID(int id)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            Usuario oUsuario = repository.GetUsuarioByID(id);
            // Desencriptar el password para presentarlo
            oUsuario.contrasenna = Cryptography.DecrypthAES(oUsuario.contrasenna);

            return oUsuario;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            return repository.GetUsuarios();
        }

        public Usuario Save(Usuario usuario)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            // Encriptar el password para guardarlo
            usuario.contrasenna = Cryptography.EncrypthAES(usuario.contrasenna);

            return repository.Save(usuario);
        }
    }
}

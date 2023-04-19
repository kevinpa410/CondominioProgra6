using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesResidencias : IServicesResidencias
    {
        public IEnumerable<Residencias> GetResidencias()
        {
            IRepositoryResidencias repository = new RepositoryResidencias();
            return repository.GetResidencias();
        }

        public Residencias GetResidenciasByID(int id)
        {
            IRepositoryResidencias repository = new RepositoryResidencias();
            return repository.GetResidenciasByID(id);
        }

        public Residencias GetResidenciasByUsuario(int idusuario)
        {
            IRepositoryResidencias repository = new RepositoryResidencias();
            return repository.GetResidenciasByUsuario(idusuario);
        }

        public Residencias Save(Residencias residencias)
        {
            IRepositoryResidencias repository = new RepositoryResidencias();
            return repository.Save(residencias);
        }
    }
}

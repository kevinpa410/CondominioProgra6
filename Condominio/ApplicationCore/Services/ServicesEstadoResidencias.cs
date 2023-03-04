using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesEstadoResidencias : IServicesEstadoResidencias
    {
        public IEnumerable<EstadoResidencias> GetEstadoResidencias()
        {
            IRepositoryEstadoResidencias repository = new RepositoryEstadoResidencias();
            return repository.GetEstadoResidencias();
        }
    }
}

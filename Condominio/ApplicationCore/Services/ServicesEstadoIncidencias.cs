using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesEstadoIncidencias : IServicesEstadoIncidencias
    {
        public IEnumerable<EstadoIncidencia> GetEstadoIncidencia()
        {
            IRepositoryEstadoIncidencias repository = new RepositoryEstadoIncidencias();
            return repository.GetEstadoIncidencia();
        }

        public EstadoIncidencia GetEstadoIncidenciaByID(int id)
        {
            RepositoryEstadoIncidencias repository = new RepositoryEstadoIncidencias();
            return repository.GetEstadoIncidenciaByID(id);
        }
    }
}

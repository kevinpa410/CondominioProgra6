using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesIncidencias : IServicesIncidencias
    {
        public IEnumerable<Incidencias> GetIncidencias()
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.GetIncidencias();
        }

        public Incidencias GetIncidenciasByID(int id)
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.GetIncidenciasByID(id);
        }

        public Incidencias Save(Incidencias incidencias)
        {
            IRepositoryIncidencias repository = new RepositoryIncidencias();
            return repository.Save(incidencias);
        }
    }
}

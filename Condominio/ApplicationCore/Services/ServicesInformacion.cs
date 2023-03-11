using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesInformacion : IServicesInformacion
    {
        public IEnumerable<Informacion> GetInformacion()
        {
            IRepositoryInformacion repository = new RepositoryInformacion();
            return repository.GetInformacion();
        }

        public Informacion GetInformacionByID(int id)
        {
            IRepositoryInformacion repository = new RepositoryInformacion();
            return repository.GetInformacionByID(id);
        }

        public Informacion Save(Informacion informacion)
        {
            IRepositoryInformacion repository = new RepositoryInformacion();
            return repository.Save(informacion);
        }
    }
}

using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesTipoInformacion : IServicesTipoInformacion
    {
        public IEnumerable<TipoInformacion> GetTipoInformacion()
        {
            IRepositoryTipoInformacion repository = new RepositoryTipoInformacion();
            return repository.GetTipoInformacion();
        }
    }
}

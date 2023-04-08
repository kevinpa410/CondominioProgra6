using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceAreaComunal : IServiceAreaComunal
    {
        public IEnumerable<AreaComunal> GetAreaComunal()
        {
            IRepositoryAreaComunal repository = new RepositoryAreaComunal();
            return repository.GetAreaComunal();
        }
    }
}

using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
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

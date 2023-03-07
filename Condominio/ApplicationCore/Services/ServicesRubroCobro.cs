using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesRubroCobro : IServicesRubroCobro
    {
        public IEnumerable<RubroCobro> GetRubroCobros()
        {
            IRepositoryRubroCobros repository = new RepositoryRubroCobros();
            return repository.GetRubroCobros();
        }

        public RubroCobro GetRubroCobroByID(int id)
        {
            IRepositoryRubroCobros repository = new RepositoryRubroCobros();
            return repository.GetRubroCobroByID(id);
        }

        public RubroCobro Save(RubroCobro rubroCobro)
        {
            IRepositoryRubroCobros repository = new RepositoryRubroCobros();
            return repository.Save(rubroCobro);
        }
    }
}

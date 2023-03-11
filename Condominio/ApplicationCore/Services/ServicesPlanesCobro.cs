using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesPlanesCobro : IServicesPlanesCobro
    {
        public IEnumerable<PlanesCobro> GetPlanesCobro()
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetPlanesCobro();
        }

        public PlanesCobro GetPlanesCobroByID(int id)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.GetPlanesCobroByID(id);
        }

        public PlanesCobro Save(PlanesCobro planesCobro, string[] selectedRubroCobro)
        {
            IRepositoryPlanCobro repository = new RepositoryPlanCobro();
            return repository.Save(planesCobro, selectedRubroCobro);
        }
    }
}

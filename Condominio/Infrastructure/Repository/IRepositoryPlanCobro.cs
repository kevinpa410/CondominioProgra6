using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryPlanCobro
    {
        IEnumerable<PlanesCobro> GetPlanesCobro();
        PlanesCobro GetPlanesCobroByID(int id);
        PlanesCobro Save(PlanesCobro planesCobro, string[] selectedRubroCobro);


    }
}

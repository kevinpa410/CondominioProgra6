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
        IEnumerable<PlanesCobro> GetEstadoCuentaByDeudasVigentes(int id = 1);

        IEnumerable<PlanesCobro> GetEstadoCuentaByHistorialPagos(int id = 2);

        IEnumerable<PlanesCobro> GetPlanesCobro();
        PlanesCobro GetPlanesCobroByID(int id);
        PlanesCobro Save(PlanesCobro planesCobro);


    }
}

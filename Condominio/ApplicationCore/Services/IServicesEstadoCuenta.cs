using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesEstadoCuenta
    {
        //IEnumerable<EstadoCuenta> GetEstadoCuentaByDeudasVigentes(int id = 1);
        //IEnumerable<EstadoCuenta> GetEstadoCuentaByHistorialPagos(int id = 2);
        IEnumerable<EstadoCuenta> GetEstadoCuenta();
        EstadoCuenta GetEstadoCuentaByID(int id);
        EstadoCuenta Save(EstadoCuenta estadoCuenta);
    }
}

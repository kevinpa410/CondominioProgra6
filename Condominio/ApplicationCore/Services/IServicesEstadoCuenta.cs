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
        IEnumerable<EstadoCuenta> GetEstadoCuentaByPagosPendientes(int IDResidencia);
        IEnumerable<EstadoCuenta> GetEstadoCuentaByHistorialPagos(int IDResidencia);
        IEnumerable<EstadoCuenta> GetEstadoCuentaByEstado(int IDResidencia, int IDEstado);
        IEnumerable<EstadoCuenta> GetEstadoCuenta();
        EstadoCuenta GetEstadoCuentaByID(int id);
        EstadoCuenta Save(EstadoCuenta estadoCuenta);
        EstadoCuenta GetEstadoCuentaByUsuario(int idusuario);
    }
}

using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryEstadoCuenta
    {
        IEnumerable<EstadoCuenta> GetEstadoCuenta();
        EstadoCuenta GetEstadoCuentaByID(int id);
        IEnumerable<EstadoCuenta> GetEstadoCuentaByEstado(int IDResidencia, int IDEstado);
        IEnumerable<EstadoCuenta> GetEstadoCuentaByPagosPendientes(int IDUsuario);
        IEnumerable<EstadoCuenta> GetEstadoCuentaByHistorialPagos(int IDUsuario);
        EstadoCuenta Save(EstadoCuenta estadoCuenta);
        EstadoCuenta GetEstadoCuentaByUsuario(int idusuario);
        IEnumerable<EstadoCuenta> GetEstadosCuentaByUsuario(int idusuario);
    }
}

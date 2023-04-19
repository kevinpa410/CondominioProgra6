using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesEstadoCuenta : IServicesEstadoCuenta
    {
        public IEnumerable<EstadoCuenta> GetEstadoCuenta()
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuenta();
        }

        public IEnumerable<EstadoCuenta> GetEstadoCuentaByEstado(int IDResidencia, int IDEstado)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaByEstado(IDResidencia, IDEstado);
        }
        public IEnumerable<EstadoCuenta> GetEstadoCuentaByHistorialPagos(int IDResidencia)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaByHistorialPagos(IDResidencia);
        }
        public IEnumerable<EstadoCuenta> GetEstadoCuentaByPagosPendientes(int IDResidencia)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaByPagosPendientes(IDResidencia);
        }
        public EstadoCuenta GetEstadoCuentaByID(int id)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaByID(id);
        }        
        public EstadoCuenta GetEstadoCuentaByUsuario(int idusuario)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaByUsuario(idusuario);
        }
        public EstadoCuenta Save(EstadoCuenta estadoCuenta)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.Save(estadoCuenta);
        }
    }
}

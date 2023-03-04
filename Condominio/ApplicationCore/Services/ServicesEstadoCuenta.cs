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

        //public IEnumerable<EstadoCuenta> GetEstadoCuentaByDeudasVigentes(int id = 1)
        //{
        //    IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
        //    return repository.GetEstadoCuentaByDeudasVigentes(id);
        //}

        //public IEnumerable<EstadoCuenta> GetEstadoCuentaByHistorialPagos(int id = 2)
        //{
        //    IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
        //    return repository.GetEstadoCuentaByHistorialPagos(id);
        //}

        public EstadoCuenta GetEstadoCuentaByID(int id)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetEstadoCuentaByID(id);
        }

        public EstadoCuenta Save(EstadoCuenta estadoCuenta)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.Save(estadoCuenta);
        }
    }
}

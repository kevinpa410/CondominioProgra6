using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesEstadoReservaciones : IServicesEstadoReservaciones
    {
        public IEnumerable<EstadoReservaciones> GetEstadoReservaciones()
        {
            IRepositoryEstadoReservaciones repository = new RepositoryEstadoReservaciones();
            return repository.GetEstadoReservaciones();
        }
    }
}

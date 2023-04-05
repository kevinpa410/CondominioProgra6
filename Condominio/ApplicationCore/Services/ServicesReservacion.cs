using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicesReservacion : IServicesReservacion
    {
        public IEnumerable<Reservaciones> GetReservaciones()
        {
            IRepositoryReservacion repository = new RepositoryReservacion();
            return repository.GetReservaciones();
        }

        public Reservaciones GetReservacionesByID(int id)
        {
            IRepositoryReservacion repository = new RepositoryReservacion();
            return repository.GetReservacionesByID(id);
        }

        public Reservaciones Save(Reservaciones reservaciones)
        {
            IRepositoryReservacion repository = new RepositoryReservacion();
            return repository.Save(reservaciones);
        }
    }
}

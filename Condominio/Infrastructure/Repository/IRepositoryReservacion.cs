using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryReservacion
    {
        IEnumerable<Reservaciones> GetReservaciones();
        Reservaciones GetReservacionesByID(int id);
        Reservaciones Save(Reservaciones reservaciones);
    }
}

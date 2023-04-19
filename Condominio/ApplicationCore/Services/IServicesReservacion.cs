using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesReservacion
    {
        IEnumerable<Reservaciones> GetReservaciones();
        Reservaciones GetReservacionesByID(int id);
        Reservaciones Save(Reservaciones reservaciones);
        IEnumerable<Reservaciones> GetReservacionesByUsuario(int idusuario);

    }
}

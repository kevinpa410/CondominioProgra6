using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesInformacion
    {
        IEnumerable<Informacion> GetInformacion();
        Informacion GetInformacionByID(int id);
        Informacion Save(Informacion informacion);
    }
}

using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesIncidencias
    {
        IEnumerable<Incidencias> GetIncidencias();

        Incidencias GetIncidenciasByID(int id);

        Incidencias Save(Incidencias incidencias);
    }
}

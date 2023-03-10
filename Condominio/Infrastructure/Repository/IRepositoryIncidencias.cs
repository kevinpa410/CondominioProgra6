using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryIncidencias
    {
        IEnumerable<Incidencias> GetIncidencias();
        Incidencias GetIncidenciasByID(int id);
        Incidencias Save(Incidencias incidencias);
    }
}

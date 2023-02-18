using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesResidencias
    {
        IEnumerable<Residencias> GetResidencias();
        Residencias GetResidenciasByID(int id);
        Residencias Save(Residencias residencias);
    }
}

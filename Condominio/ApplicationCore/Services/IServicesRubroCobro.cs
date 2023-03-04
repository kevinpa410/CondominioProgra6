using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesRubroCobro
    {
        IEnumerable<RubroCobro> GetResidencias();
        RubroCobro GetRubroCobroByID(int id);
        RubroCobro Save(RubroCobro rubroCobro);
    }
}

using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryRubroCobros
    {
        IEnumerable<RubroCobro> GetRubroCobros();
        RubroCobro GetRubroCobroByID(int id);
        RubroCobro Save(RubroCobro rubroCobro);
    }
}

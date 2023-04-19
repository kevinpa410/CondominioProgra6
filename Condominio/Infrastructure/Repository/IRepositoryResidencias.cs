using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryResidencias
    {

        IEnumerable<Residencias> GetResidencias();
        Residencias GetResidenciasByID(int id);
        Residencias Save(Residencias residencias);
        Residencias GetResidenciasByUsuario(int idusuario);
    }



}

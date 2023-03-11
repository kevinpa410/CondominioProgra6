﻿using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicesEstadoIncidencias
    {
        IEnumerable<EstadoIncidencia> GetEstadoIncidencia();
        EstadoIncidencia GetEstadoIncidenciaByID(int id);
    }
}

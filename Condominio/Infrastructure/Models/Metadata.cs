using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Models
{
    internal partial class Metadata
    {
        internal partial class RecidenciaMetadata
        {
            [Display(Name = "ID ")]
            public int ID { get; set; }
            [Display(Name = "ID Usuario")]
            public int IDUsuario { get; set; }
            [Display(Name = "ID Estado")]
            public Nullable<int> IDEstado { get; set; }
            [Display(Name = "Cantidad de Personas")]
            public Nullable<int> CantPersonas { get; set; }
            [Display(Name = "Año de Inicio")]
            public Nullable<System.DateTime> AnnoInicio { get; set; }
            [Display(Name = "Cantidad de Carros")]
            public Nullable<int> CantCarros { get; set; }
        }

        internal partial class EstadoCuentaMetadata
        {
            [Display(Name = "ID del Estado de Cuenta")]
            public int ID { get; set; }
            [Display(Name = "ID Plan de Cobro")]
            public Nullable<int> IDPlanCobro { get; set; }
            [Display(Name = "ID de Usuario")]
            public Nullable<int> IDUsuario { get; set; }
            [Display(Name = "ID de Residencia")]
            public Nullable<int> IDResidencia { get; set; }
            [Display(Name = "ID de Estado")]
            public Nullable<int> IDEstado { get; set; }
            public Nullable<System.DateTime> Mes { get; set; }

        }

        internal partial class PlanesCobroMetadata
        {
            [Display(Name = "ID Plan de Cobro")]
            public int ID { get; set; }
            public Nullable<decimal> Total { get; set; }
            public string Descripcion { get; set; }

        }

        internal partial class UsuarioMetadata
        {
            public int ID { get; set; }
            [Display(Name = "Correo")]
            public string correo { get; set; }
            [Display(Name = "Contraseña")]
            public string contrasenna { get; set; }
            [Display(Name = "Nombre")]
            public string nombre { get; set; }
            [Display(Name = "Apellido")]
            public string apellido { get; set; }
            [Display(Name = "ID de Rol")]
            public Nullable<int> IDRol { get; set; }
            public virtual Rol Rol { get; set; }

        }

        internal partial class InformacionMetadata
        {
            [Display(Name = "ID ")]
            public int ID { get; set; }
            [Display(Name = "Descripcion")]
            public string Descripcion { get; set; }
            public byte[] Imagen { get; set; }
    }

        internal partial class IncidenciasMetadata
        {
            [Display(Name = "ID")]
            public int ID { get; set; }
            [Display(Name = "ID Estado")]
            public Nullable<int> IDEstado { get; set; }
            [Display(Name = "ID Residencias")]
            public Nullable<int> IDResidencias { get; set; }
            [Display(Name = "Descripcion de la Incidencia")]
            public string Descripcion { get; set; }
        }

        internal partial class RubroCobroMetadata
        {
            [Display(Name = "ID Rubro de Cobro")]
            public int ID { get; set; }
            public Nullable<decimal> Monto { get; set; }
            public string Descripcion { get; set; }

        }

        internal partial class ReservacionesMetadata
        {
            [Display(Name = "ID de Reservacion")]
            public int ID { get; set; }
            [Display(Name = "ID de Usuario")]
            public Nullable<int> IDUsuario { get; set; }
            [Display(Name = "ID de Area Comunal")]
            public Nullable<int> IDAreaComunal { get; set; }
            public Nullable<System.DateTime> Fecha { get; set; }
        }

        internal partial class EstadoResidenciasMetadata
        {
            [Display(Name = "ID Estado de Residencias")]
            public int ID { get; set; }
            [Display(Name = "Estado de Residencias ")]
            public string Descripcion { get; set; }
        }

        internal partial class RolMetadata
        {
            [Display(Name = "ID Rol")]
            public int ID { get; set; }
            [Display(Name = "Rol del Usuario")]
            public string descripcion { get; set; }
        }

        internal partial class EstadoReservacionesMetadata
        {
            [Display(Name = "ID Estado de la Reservacion")]
            public int ID { get; set; }
            [Display(Name = "Estado de la Reservacion")]
            public string Descripcion { get; set; }
        }

        internal partial class EstadoIncidenciaMetadata
        {
            [Display(Name = "ID de Estado de Incidencia")]
            public int ID { get; set; }
            [Display(Name = "Estado de Incidencia")]
            public string Descripcion { get; set; }
        }

        internal partial class TipoInformacionMetadata
        {
            [Display(Name = "ID Tipo Informacion")]
            public int ID { get; set; }
            [Display(Name = "Tipo de Informacion")]
            public string Descripcion { get; set; }
        }

        internal partial class Estado_EstadoCuentaMetadata
        {
            [Display(Name = "ID Estado del Estado de Cuenta")]
            public int ID { get; set; }
            [Display(Name = "Estado Actual")]
            public string Descripcion { get; set; }
        }

        internal partial class AreaComunalMetadata
        {
            [Display(Name = "ID del Area Comunal")]
            public int ID { get; set; }
            [Display(Name = "Nombre del Area Comunal")]
            public string Descripcion { get; set; }
        }

        //internal partial class Metadata
        //{

        //}


    }
}

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
            [Display(Name = "ID de Residencia")]
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
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "ID Plan de Cobro")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<int> IDPlanCobro { get; set; }
            [Display(Name = "ID de Usuario")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<int> IDUsuario { get; set; }
            [Display(Name = "ID de Residencia")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<int> IDResidencia { get; set; }
            [Display(Name = "ID de Estado")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<int> IDEstado { get; set; }
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<System.DateTime> Mes { get; set; }

        }

        internal partial class PlanesCobroMetadata
        {
            [Display(Name = "ID Plan de Cobro")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<decimal> Total { get; set; }
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public string Descripcion { get; set; }

        }

        internal partial class UsuarioMetadata
        {
            [Display(Name = "ID de Usuario")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Correo")]
            [DataType(DataType.EmailAddress, ErrorMessage = "{0} no tiene formato válido")]
            public string correo { get; set; }
            [Display(Name = "Contraseña")]
            public string contrasenna { get; set; }
            [Display(Name = "Nombre")]
            public string nombre { get; set; }
            [Display(Name = "Apellido")]
            public string apellido { get; set; }
            [Display(Name = "ID de Rol")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<int> IDRol { get; set; }

        }

        internal partial class InformacionMetadata
        {
            [Display(Name = "ID de Informacion")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Descripcion")]
            public string Descripcion { get; set; }
            public byte[] Imagen { get; set; }
    }

        internal partial class IncidenciasMetadata
        {
            [Display(Name = "ID de Incidencia")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "ID Estado")]
            public Nullable<int> IDEstado { get; set; }
            [Display(Name = "ID Residencias")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<int> IDResidencias { get; set; }
            [Display(Name = "Descripcion de la Incidencia")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public string Descripcion { get; set; }
        }

        internal partial class RubroCobroMetadata
        {
            [Display(Name = "ID Rubro de Cobro")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "ID Rubro de Cobro")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<decimal> Monto { get; set; }
            public string Descripcion { get; set; }

        }

        internal partial class ReservacionesMetadata
        {
            [Display(Name = "ID de Reservacion")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "ID de Usuario")]
            public Nullable<int> IDUsuario { get; set; }
            [Display(Name = "ID de Area Comunal")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<int> IDAreaComunal { get; set; }
            [Display(Name = "Fecha Orden")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public Nullable<System.DateTime> Fecha { get; set; }
        }

        internal partial class EstadoResidenciasMetadata
        {
            [Display(Name = "ID Estado de Residencias")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Estado de Residencias ")]
            public string Descripcion { get; set; }
        }

        internal partial class RolMetadata
        {
            [Display(Name = "ID Rol")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Nombre del Area Comunal")]            
            public string descripcion { get; set; }
        }

        internal partial class EstadoReservacionesMetadata
        {
            [Display(Name = "ID Estado de la Reservacion")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Estado de la Reservacion")]
            public string Descripcion { get; set; }
        }

        internal partial class EstadoIncidenciaMetadata
        {
            [Display(Name = "ID de Estado de Incidencia")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Estado de Incidencia")]
            public string Descripcion { get; set; }
        }

        internal partial class TipoInformacionMetadata
        {
            [Display(Name = "ID Tipo Informacion")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Tipo de Informacion")]
            public string Descripcion { get; set; }
        }

        internal partial class Estado_EstadoCuentaMetadata
        {
            [Display(Name = "ID Estado del Estado de Cuenta")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Estado Actual")]
            public string Descripcion { get; set; }
        }

        internal partial class AreaComunalMetadata
        {
            [Display(Name = "ID del Area Comunal")]
            [RegularExpression(@"^\d+$", ErrorMessage = "{0} solo acepta números")]
            [Required(ErrorMessage = "{0} es un dato requerido")]
            public int ID { get; set; }
            [Display(Name = "Nombre del Area Comunal")]
            public string Descripcion { get; set; }
        }

        //internal partial class Metadata
        //{

        //}


    }
}

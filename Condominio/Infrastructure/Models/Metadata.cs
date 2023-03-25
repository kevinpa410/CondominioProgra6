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
            [Display(Name = "Año de inicio")]
            public Nullable<System.DateTime> AnnoInicio { get; set; }
            [Display(Name = "Cantidad de Carros")]
            public Nullable<int> CantCarros { get; set; }
            [Display(Name = "Estado de Cuenta")]
            public virtual ICollection<EstadoCuenta> EstadoCuenta { get; set; }
            [Display(Name = "Estado de Residencias")]
            public virtual EstadoResidencias EstadoResidencias { get; set; }
            public virtual ICollection<Incidencias> Incidencias { get; set; }
            public virtual Usuario Usuario { get; set; }

        }

        internal partial class EstadoCuentaMetadata
        {
            [Display(Name = "ID ")]
            public int ID { get; set; }
            [Display(Name = "ID Plan de Cobro")]
            public Nullable<int> IDPlanCobro { get; set; }
            [Display(Name = "ID Usuario")]
            public Nullable<int> IDUsuario { get; set; }
            [Display(Name = "ID Residencia")]
            public Nullable<int> IDResidencia { get; set; }
            public Nullable<decimal> Total { get; set; }
            public Nullable<System.DateTime> Mes { get; set; }
            [Display(Name = "Planes de Cobro")]
            public virtual PlanesCobro PlanesCobro { get; set; }
            public virtual Residencias Residencias { get; set; }
            public virtual Usuario Usuario { get; set; }

        }

        internal partial class PlanesCobroMetadata
        {
            [Display(Name = "ID Plan de Cobro")]
            public int ID { get; set; }
            public Nullable<decimal> Total { get; set; }

        }

        internal partial class UsuarioMetadata
        {

            public int ID { get; set; }
            [Display(Name = "Correo")]
            public string correo { get; set; }
            public string contrasenna { get; set; }
            [Display(Name = "Nombre")]
            public string nombre { get; set; }
            [Display(Name = "Apellido")]
            public string apellido { get; set; }
            [Display(Name = "Rol")]
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
            [Display(Name = "Descripcion")]
            public string Descripcion { get; set; }

            public virtual EstadoIncidencia EstadoIncidencia { get; set; }
            public virtual Residencias Residencias { get; set; }
        }

        internal partial class RubroCobroMetadata
        {
            public int ID { get; set; }
            public Nullable<decimal> Monto { get; set; }
            public string Descripcion { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<PlanesCobro> PlanesCobro { get; set; }
        }


        //internal partial class Metadata
        //{

        //}

    }
}

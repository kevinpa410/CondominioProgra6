//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Infrastructure.Models.Metadata;

    [MetadataType(typeof(EstadoCuentaMetadata))]
    public partial class EstadoCuenta
    {
        public int ID { get; set; }
        public Nullable<int> IDPlanCobro { get; set; }
        public Nullable<int> IDUsuario { get; set; }
        public Nullable<int> IDResidencia { get; set; }
        public Nullable<int> IDEstado { get; set; }
        public Nullable<System.DateTime> Mes { get; set; }
    
        public virtual Estado_EstadoCuenta Estado_EstadoCuenta { get; set; }
        public virtual PlanesCobro PlanesCobro { get; set; }
        public virtual Residencias Residencias { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}

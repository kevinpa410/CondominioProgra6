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

    [MetadataType(typeof(IncidenciasMetadata))]
    public partial class Incidencias
    {
        public int ID { get; set; }
        public Nullable<int> IDEstado { get; set; }
        public Nullable<int> IDResidencias { get; set; }
        public string Descripcion { get; set; }
    
        public virtual EstadoIncidencia EstadoIncidencia { get; set; }
        public virtual Residencias Residencias { get; set; }
    }
}

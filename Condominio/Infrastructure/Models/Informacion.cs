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

    [MetadataType(typeof(InformacionMetadata))]
    public partial class Informacion
    {
        public int ID { get; set; }
        public Nullable<int> IDTipoInformacion { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
    
        public virtual TipoInformacion TipoInformacion { get; set; }
    }
}

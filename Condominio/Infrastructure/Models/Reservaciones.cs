//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservaciones
    {
        public int ID { get; set; }
        public Nullable<int> IDUsuario { get; set; }
        public Nullable<int> IDAreaComunal { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual AreaComunal AreaComunal { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
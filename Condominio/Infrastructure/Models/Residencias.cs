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
    
    public partial class Residencias
    {
        public int ID { get; set; }
        public int IDUsuario { get; set; }
        public Nullable<int> IDEstado { get; set; }
        public Nullable<int> IDPlanAsignado { get; set; }
        public Nullable<int> IDIncidencias { get; set; }
        public Nullable<int> CantPersonas { get; set; }
        public Nullable<System.DateTime> AnnoInicio { get; set; }
        public Nullable<int> CantCarros { get; set; }
    
        public virtual EstadoResidencias EstadoResidencias { get; set; }
        public virtual Incidencias Incidencias { get; set; }
        public virtual PlanAsignado PlanAsignado { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
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
    
    public partial class PlanAsignado
    {
        public PlanAsignado()
        {
            this.Residencias = new HashSet<Residencias>();
        }
    
        public int ID { get; set; }
        public Nullable<int> IDPlanCobro { get; set; }
        public Nullable<int> IDCondominio { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> Mes { get; set; }
    
        public virtual PlanesCobro PlanesCobro { get; set; }
        public virtual ICollection<Residencias> Residencias { get; set; }
    }
}

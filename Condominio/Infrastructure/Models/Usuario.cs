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
    
    public partial class Usuario
    {
        public Usuario()
        {
            this.Reservaciones = new HashSet<Reservaciones>();
            this.Residencias = new HashSet<Residencias>();
        }
    
        public int ID { get; set; }
        public string correo { get; set; }
        public string contrasenna { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<int> IDRol { get; set; }
        public Nullable<int> activo { get; set; }
    
        public virtual ICollection<Reservaciones> Reservaciones { get; set; }
        public virtual ICollection<Residencias> Residencias { get; set; }
        public virtual Rol Rol { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositorio
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clubes
    {
        public Clubes()
        {
            this.Equipos = new HashSet<Equipos>();
        }
    
        public int idClub { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
    
        public virtual ICollection<Equipos> Equipos { get; set; }
    }
}
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
    
    public partial class Arbitros
    {
        public Arbitros()
        {
            this.Partidos1 = new HashSet<Partidos>();
            this.Partidos2 = new HashSet<Partidos>();
            this.SancionesJugador = new HashSet<SancionesJugador>();
        }
    
        public int idArbitro { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public Nullable<int> Partidos { get; set; }
        public Nullable<int> TarjetasAmarillas { get; set; }
        public Nullable<int> TarjetasRojas { get; set; }
    
        public virtual ICollection<Partidos> Partidos1 { get; set; }
        public virtual ICollection<Partidos> Partidos2 { get; set; }
        public virtual ICollection<SancionesJugador> SancionesJugador { get; set; }
    }
}
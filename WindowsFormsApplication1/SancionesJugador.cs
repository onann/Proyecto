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
    
    public partial class SancionesJugador
    {
        public int idSancionJugador { get; set; }
        public Nullable<int> idJugador { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> multa { get; set; }
        public Nullable<int> idCategoria_Sancion { get; set; }
        public Nullable<int> idArbitro { get; set; }
    
        public virtual Arbitros Arbitros { get; set; }
        public virtual CategoriasSanciones CategoriasSanciones { get; set; }
        public virtual Jugadores Jugadores { get; set; }
    }
}

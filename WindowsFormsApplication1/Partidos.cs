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
    
    public partial class Partidos
    {
        public Partidos()
        {
            this.EstadisticasPartidos = new HashSet<EstadisticasPartidos>();
        }
    
        public int idPartido { get; set; }
        public Nullable<int> idLiga { get; set; }
        public Nullable<int> idEquipoLocal { get; set; }
        public Nullable<int> idEquipoVisitante { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> idCampo { get; set; }
        public Nullable<int> idLive { get; set; }
        public Nullable<int> idArbitro { get; set; }
    
        public virtual Arbitros Arbitros { get; set; }
        public virtual Arbitros Arbitros1 { get; set; }
        public virtual Campos Campos { get; set; }
        public virtual ICollection<EstadisticasPartidos> EstadisticasPartidos { get; set; }
        public virtual Ligas Ligas { get; set; }
        public virtual Live Live { get; set; }
    }
}

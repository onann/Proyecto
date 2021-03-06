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
    
    public partial class Equipos
    {
        public Equipos()
        {
            this.EstadisticasPartidos = new HashSet<EstadisticasPartidos>();
            this.Jugadores = new HashSet<Jugadores>();
            this.Sanciones_Equipo = new HashSet<Sanciones_Equipo>();
            this.Partidos = new HashSet<Partidos>();
            this.Partidos1 = new HashSet<Partidos>();
        }
    
        public int idEquipo { get; set; }
        public int idClub { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> idLiga { get; set; }
        public int Puntos { get; set; }
        public Nullable<int> Partidos_Jugados { get; set; }
        public Nullable<int> Partidos_Ganados { get; set; }
        public Nullable<int> Partidos_Perdidos { get; set; }
        public Nullable<int> Partidos_Empatados { get; set; }
        public Nullable<int> Puntos_Encajados { get; set; }
        public Nullable<int> Puntos_Anotados { get; set; }
    
        public virtual Clubes Clubes { get; set; }
        public virtual Ligas Ligas { get; set; }
        public virtual ICollection<EstadisticasPartidos> EstadisticasPartidos { get; set; }
        public virtual ICollection<Jugadores> Jugadores { get; set; }
        public virtual ICollection<Sanciones_Equipo> Sanciones_Equipo { get; set; }
        public virtual ICollection<Partidos> Partidos { get; set; }
        public virtual ICollection<Partidos> Partidos1 { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProyectoEntities1 : DbContext
    {
        public ProyectoEntities1()
            : base("name=ProyectoEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Arbitros> Arbitros { get; set; }
        public virtual DbSet<Campos> Campos { get; set; }
        public virtual DbSet<Categoria_Ligas> Categoria_Ligas { get; set; }
        public virtual DbSet<Clubes> Clubes { get; set; }
        public virtual DbSet<ComentariosLive> ComentariosLive { get; set; }
        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<EstadisticasPartidos> EstadisticasPartidos { get; set; }
        public virtual DbSet<Jugadores> Jugadores { get; set; }
        public virtual DbSet<Ligas> Ligas { get; set; }
        public virtual DbSet<Live> Live { get; set; }
        public virtual DbSet<Partidos> Partidos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}

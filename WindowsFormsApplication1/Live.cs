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
    
    public partial class Live
    {
        public Live()
        {
            this.ComentariosLive = new HashSet<ComentariosLive>();
            this.Partidos = new HashSet<Partidos>();
        }
    
        public int idLive { get; set; }
        public Nullable<int> TiempoTranscurrido { get; set; }
    
        public virtual ICollection<ComentariosLive> ComentariosLive { get; set; }
        public virtual ICollection<Partidos> Partidos { get; set; }
    }
}

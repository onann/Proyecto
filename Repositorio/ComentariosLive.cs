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
    
    public partial class ComentariosLive
    {
        public int idComentario { get; set; }
        public Nullable<int> idLive { get; set; }
        public string texto { get; set; }
        public Nullable<int> minuto { get; set; }
    
        public virtual Live Live { get; set; }
    }
}
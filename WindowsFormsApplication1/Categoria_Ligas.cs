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
    
    public partial class Categoria_Ligas
    {
        public Categoria_Ligas()
        {
            this.Ligas = new HashSet<Ligas>();
        }
    
        public int idCategoriaLiga { get; set; }
        public string NombreCategoria { get; set; }
    
        public virtual ICollection<Ligas> Ligas { get; set; }
    }
}

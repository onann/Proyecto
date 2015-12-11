using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.ComentariosLive
{
    public class ComentariosLive
    {
        
        [Display(Name = "idComentario")]
        public int idComentario { get; set; }
        [Display(Name = "idLive")]
        public int? idLive { get; set; }
        [Display(Name = "Comentario")]
        public string texto { get; set; }
        [Display(Name = "Hora")]
        public DateTime? horaPublicacion { get; set; }
        [Display(Name = "Nuevo marcador local")]
         public int? marcadorLocal { get; set; }
        [Display(Name = "Nuevo marcador visitante")]
         public int? marcadorVisitatne { get; set; }
    
    }
}
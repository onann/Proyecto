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
        [StringLength(50)]
        [Display(Name = "idComentario")]
        public int idComentario { get; set; }
        [StringLength(50)]
        [Display(Name = "idLive")]
        public int? idLive { get; set; }
        [StringLength(50)]
        [Display(Name = "texto")]
        public string texto { get; set; }
        [StringLength(50)]
        [Display(Name = "minuto")]
        public int? minuto { get; set; }
    }
}
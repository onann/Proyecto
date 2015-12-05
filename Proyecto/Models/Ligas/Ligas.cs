using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Ligas
{
    public class Ligas
    {
        [Display(Name = "idLiga")]
        public int idLiga { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "nombre")]
        public string nombre { get; set; }
        [Display(Name = "idCategoriaLiga")]
        public int? idCategoriaLiga { get; set; }
       
    }
}
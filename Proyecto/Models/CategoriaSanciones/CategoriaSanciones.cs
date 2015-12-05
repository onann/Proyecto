using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.CategoriaSanciones
{
    public class CategoriaSanciones
    {
        [StringLength(50)]
        [Display(Name = "idCategoriaSancion")]
        public int idCategoriaSancion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [StringLength(250)]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Categoria_Ligas
{
    public class Categoria_Ligas
    {
        [Display(Name = "idCategoriaLiga")]
        public int idCategoriaLiga { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "NombreCategoria")]
        public string NombreCategoria { get; set; }
        
    }
}
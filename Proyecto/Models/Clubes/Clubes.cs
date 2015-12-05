using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Clubes
{
    public class Clubes
    {
        [Display(Name = "idClub")]
        public int idClub { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }
        [StringLength(50)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Proyecto.Models.Campos
{
    public class Campos
    {
        [Display(Name = "idCampo")]
        public int idCampo { get; set; }
        [Display(Name = "idClub")]
        public int idEquipo { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
    }
}
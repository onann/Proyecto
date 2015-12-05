using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models.Sanciones_Equipo
{
    public class Sanciones_Equipo
    {
        [Display(Name = "idSancion_Equipo")]
        public int idSancion_Equipo { get; set; }
        [StringLength(50)]
        [Display(Name = "descripcion")]
        public string descripcion { get; set; }
        [Required]
        [Display(Name = "multa")]
        public decimal multa { get; set; }
        [Display(Name = "idCategoria_Sancion")]
        public int? idCategoria_Sancion { get; set; }
        [Display(Name = "idEquipo")]
        public int idEquipo { get; set; }
    }
}
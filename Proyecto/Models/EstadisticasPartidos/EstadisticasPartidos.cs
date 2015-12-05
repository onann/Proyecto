using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.EstadisticasPartidos
{
    public class EstadisticasPartidos
    {
        [Display(Name = "idEstadistica_Partido")]
        public int idEstadistica_Partido { get; set; }
        [Required]
        [Display(Name = "idPartido")]
        public int idPartido { get; set; }
        [Required]
        [Display(Name = "idEquipo")]
        public int idEquipo { get; set; }
        [Display(Name = "Ensayos")]
        public int? Ensayos { get; set; }
        [Display(Name = "Conversiones")]
        public int? Conversiones { get; set; }
        [Display(Name = "GolpesCastigo")]
        public int? GolpesCastigo { get; set; }
        [Display(Name = "Drops")]
        public int? Drops { get; set; }
        [Display(Name = "TarjetasAmarillas")]
        public int? TarjetasAmarillas { get; set; }
        [Display(Name = "TarjetasRojas")]
        public int? TarjetasRojas { get; set; }
    }
}
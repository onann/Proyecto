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
        [Display(Name = "Golpes de castigo")]
        public int? GolpesCastigo { get; set; }
        [Display(Name = "Drops")]
        public int? Drops { get; set; }
        [Display(Name = "Tarjetas amarillas")]
        public int? TarjetasAmarillas { get; set; }
        [Display(Name = "Tarjetas rojas")]
        public int? TarjetasRojas { get; set; }
        [Display(Name = "Marcador")]
        public int Marcador { get; set; }

        [Display(Name = "idEstadistica_Partido2")]
        public int idEstadistica_Partido2 { get; set; }
        [Required]
        [Display(Name = "idPartido2")]
        public int idPartido2 { get; set; }
        [Required]
        [Display(Name = "idEquipo2")]
        public int idEquipo2 { get; set; }
        [Display(Name = "Ensayos")]
        public int? Ensayos2 { get; set; }
        [Display(Name = "Conversiones")]
        public int? Conversiones2 { get; set; }
        [Display(Name = "Golpes de castigo")]
        public int? GolpesCastigo2 { get; set; }
        [Display(Name = "Drops")]
        public int? Drops2 { get; set; }
        [Display(Name = "Tarjetas amarillas")]
        public int? TarjetasAmarillas2 { get; set; }
        [Display(Name = "Tarjetas rojas")]
        public int? TarjetasRojas2 { get; set; }
        [Display(Name = "Marcador2")]
        public int Marcador2{ get; set; }
    }
}
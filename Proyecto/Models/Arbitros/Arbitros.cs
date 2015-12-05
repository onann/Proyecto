using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Arbitros
{
    public class Arbitros
    {
        [Display(Name = "IdArbitro")]
        public int idArbitro { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido1")]
        public string Apellido1 { get; set; }
        [StringLength(50)]
        [Display(Name = "Apellido2")]
        public string Apellido2 { get; set; }
        [Display(Name = "Fecha_Nacimiento")]
        public DateTime? Fecha_Nacimiento { get; set; }
        [Display(Name = "Partidos")]
        public int? Partidos { get; set; }
        [Display(Name = "TarjetasAmarillas")]
        public int? TarjetasAmarillas { get; set; }
        [Display(Name = "TarjetasRojas")]
        public int? TarjetasRojas { get; set; }
        
    }
}
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
        [Display(Name = "Primer apellido")]
        public string Apellido1 { get; set; }
        [StringLength(50)]
        [Display(Name = "Segundo apellido")]
        public string Apellido2 { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? Fecha_Nacimiento { get; set; }
        [Display(Name = "Partidos")]
        public int? Partidos { get; set; }
        [Display(Name = "Tarjetas amarillas")]
        public int? TarjetasAmarillas { get; set; }
        [Display(Name = "Tarjetas rojas")]
        public int? TarjetasRojas { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        public virtual string fechaIntroducida { get; set; }

    }
}
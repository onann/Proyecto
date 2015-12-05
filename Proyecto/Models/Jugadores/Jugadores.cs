using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Jugadores
{
    public class Jugadores
    {
        
        [Display(Name = "idJugador")]
        public int idJugador { get; set; }
        [Display(Name = "idEquipo")]
        public int? idEquipo { get; set; }
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
        [StringLength(50)]
        [Display(Name = "Fecha_Nacimiento")]
        public DateTime? Fecha_Nacimiento { get; set; }
        [Display(Name = "Altura")]
        public int? Altura { get; set; }
        [Display(Name = "Peso")]
        public int? Peso { get; set; }
        [Display(Name = "Puntos")]
        public int? Puntos { get; set; }
        [Display(Name = "Partidos_Jugados")]
        public int? Partidos_Jugados { get; set; }
        [Display(Name = "Partidos_Ganados")]
        public int? Partidos_Ganados { get; set; }
        [Display(Name = "Partidos_Perdidos")]
        public int? Partidos_Perdidos { get; set; }
        [Display(Name = "Partidos_Empatados")]
        public int? Partidos_Empatados { get; set; }
        [Display(Name = "TarjetasAmarillas")]
        public int? TarjetasAmarillas { get; set; }
        [Display(Name = "TarjetasRojas")]
        public int? TarjetasRojas { get; set; }

        public virtual Equipos.Equipos equipo { get; set; }
        public virtual string fechaIntroducida { get; set;}
    }
}
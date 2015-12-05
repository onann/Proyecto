using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Proyecto.Models.Equipos
{
    public class Equipos
    {
        [Required]
        [Display(Name = "idEquipo")]
        public int idEquipo { set; get; }
        [Required]
        [Display(Name = "Club")]
        public int idClub { set; get; }
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { set; get; }
        [Display(Name = "idLiga")]
        public int? idLiga { set; get; }
        [Required]        
        [Display(Name = "Puntos")]
        public int Puntos { set; get; }
        [Display(Name = "Partidos_Jugados")]
        public int? Partidos_Jugados { set; get; }
        [Display(Name = "Partidos_Ganados")]
        public int? Partidos_Ganados { set; get; }
        [Display(Name = "Partidos_Perdidos")]
        public int? Partidos_Perdidos { set; get; }
        [Display(Name = "Partidos_Empatados")]
        public int? Partidos_Empatados { set; get; }
        [Display(Name = "Puntos_Encajados")]
        public int? Puntos_Encajados { set; get; }
        [Display(Name = "Puntos_Anotados")]
        public int? Puntos_Anotados { set; get; }


        public virtual Clubes.Clubes club { get; set; }
        public virtual Ligas.Ligas liga { get; set; }
    }
}
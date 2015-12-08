using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models.Partidos
{
    public class Partidos
    {
        [Display(Name = "idPartido")]
        public int idPartido { get; set; }
        [Display(Name = "idLiga")]
        public int? idLiga { get; set; }
        [Required]
        [Display(Name = "Local")]
        public int idEquipoLocal { get; set; }
        [Required]
        [Display(Name = "Visitante")]
        public int idEquipoVisitante { get; set; }
        [Display(Name = "Date")]
        public DateTime? Date { get; set; }
        [Display(Name = "Campo")]
        public int? idCampo { get; set; }
        [Display(Name = "idLive")]
        public int? idLive { get; set; }
        [Display(Name = "Arbitro")]
        public int? idArbitro { get; set; }
        [Display(Name = "isJugado")]
        public bool isJugado { get; set; }

        public virtual Equipos.Equipos equipos { get; set; }
        public virtual Arbitros.Arbitros arbitros { get; set; }
        public virtual Campos.Campos campos { get; set; }
        public virtual Ligas.Ligas ligas { get; set; }
    }
}
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
        [Display(Name = "idEquipoLocal")]
        public int idEquipoLocal { get; set; }
        [Required]
        [Display(Name = "idEquipoVisitante")]
        public int idEquipoVisitante { get; set; }
        [Display(Name = "Date")]
        public DateTime? Date { get; set; }
        [Display(Name = "idCampo")]
        public int? idCampo { get; set; }
        [Display(Name = "idLive")]
        public int? idLive { get; set; }
        [Display(Name = "idArbitro")]
        public int? idArbitro { get; set; }
        

    }
}
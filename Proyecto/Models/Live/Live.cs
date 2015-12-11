using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models.Live
{
    public class Live
    {
        [Display(Name = "idLive")]
        public int idLive { get; set; }
        [Display(Name = "TiempoTranscurrido")]
        public int? TiempoTranscurrido { get; set; }
        [Display(Name = "idLocal")]
        public int? idLocal { get; set; }
        [Display(Name = "idVisitante")]
        public int? idVisitante { get; set; }
        [Display(Name = "marcadorLocal")]
        public int? marcadorLocal { get; set; }
        [Display(Name = "marcadorVisitante")]
        public int? marcadorVisitante { get; set; }
        [Display(Name = "Date")]
        public DateTime? Date { get; set; }
        [Display(Name = "idCampo")]
        public int? idCampo { get; set; }
        [Display(Name = "idArbitro")]
        public int? idArbitro { get; set; }

        public string nombreLocal { get; set; }
        public string nombreVisitante { get; set; }
        public string nombreArbitro { get; set; }
        public string nombreCampo { get; set; }
    }
}
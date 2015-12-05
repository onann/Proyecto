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
    }
}
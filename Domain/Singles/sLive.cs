using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sLive
    {
        public int idLive { get; set; }
        public int? TiempoTranscurrido { get; set; }
        public int? idLocal { get; set; }
        public int? idVisitante { get; set; }
        public int? marcadorLocal { get; set; }
        public int? marcadorVisitante { get; set; }
        public DateTime? Date { get; set; }
        public int? idCampo { get; set; }
        public int? idArbitro { get; set; }
    }
}

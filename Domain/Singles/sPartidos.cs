using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sPartidos
    {
        public int idPartido { get; set; }
        public int? idLiga { get; set; }
        public int idEquipoLocal { get; set; }
        public int idEquipoVisitante { get; set; }
        public DateTime? Date { get; set; }
        public int? idCampo { get; set; }
        public int? idLive { get; set; }
        public int? idArbitro { get; set; }
        public string nombreLocal { get; set; }
        public string nombreVisitante { get; set; }
        public string nombreCampo { get; set; }
        public string nombreArbitro { get; set; }
        public string resultado { get; set; }

    }
}

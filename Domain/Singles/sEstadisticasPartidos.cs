using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sEstadisticasPartidos
    {
        public int idEstadistica_Partido { get; set; }
        public int idPartido { get; set; }
        public int idEquipo { get; set; }
        public int? Ensayos { get; set; }
        public int? Conversiones { get; set; }
        public int? GolpesCastigo { get; set; }
        public int? Drops { get; set; }
        public int? TarjetasAmarillas { get; set; }
        public int? TarjetasRojas { get; set; }
        public int? totalPuntos { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sEquipos
    {
        public int idEquipo { set; get; }
        public int idClub { set; get; }
        public string Nombre { set; get; }
        public int? idLiga { set; get; }
        public int Puntos { set; get; }
        public int? Partidos_Jugados { set; get; }
        public int? Partidos_Ganados { set; get; }
        public int? Partidos_Perdidos { set; get; }
        public int? Partidos_Empatados { set; get; }
        public int? Puntos_Encajados { set; get; }
        public int? Puntos_Anotados { set; get; }
        public string nombreLiga { get; set; }
        public string nombreClub { get; set; }

    }
}

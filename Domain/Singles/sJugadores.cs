using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sJugadores
    {
        public int idJugador { get; set; }
        public int? idEquipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public int? Altura { get; set; }
        public int? Peso { get; set; }
        public int? Puntos { get; set; }
        public int? Partidos_Jugados { get; set; }
        public int? Partidos_Ganados { get; set; }
        public int? Partidos_Perdidos { get; set; }
        public int? Partidos_Empatados { get; set; }
        public int? TarjetasAmarillas { get; set; }
        public int? TarjetasRojas { get; set; }

    }
}

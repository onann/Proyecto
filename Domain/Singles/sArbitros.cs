using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sArbitros
    {
        public int idArbitro { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public int? Partidos { get; set; }
        public int? TarjetasAmarillas { get; set; }
        public int? TarjetasRojas { get; set; }
        public string ReturnDateForDisplay
        {
            get
            {
                return this.Fecha_Nacimiento.Value.ToShortDateString();
            }
        }

    }
}

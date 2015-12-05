using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sSanciones_Equipo
    {
        public int idSancion_Equipo { get; set; }
        public string descripcion { get; set; }
        public decimal multa { get; set; }
        public int? idCategoria_Sancion { get; set; }
        public int idEquipo { get; set; }

    }
}

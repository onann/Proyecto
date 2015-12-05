using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sSancionesJugador
    {        
        public int idSancionJugador {get; set;}
        public int idJugador {get; set;}
        public string Descripcion { get; set; }
        public decimal multa { get; set; }
        public int? idCategoria_Sancion { get; set; }
        public int? idArbitro { get; set; }

    }
}

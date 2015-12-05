using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Singles
{
    public class sComentariosLive
    {
        public int idComentario { get; set; }
        public int? idLive { get; set; }
        public string texto { get; set; }
        public int? minuto { get; set; }
    }
}

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
        public DateTime? horaPublicacion { get; set; }


        public string ReturnDateForDisplay
        {
            get
            {
                return this.horaPublicacion.Value.ToShortDateString();
            }
        }

        public string ReturnHourForDisplay
        {
            get
            {
                return this.horaPublicacion.Value.ToShortTimeString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;


namespace Domain.Collections
{
    public class cLive
    {
        public List<Singles.sLive> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLive> eList = new List<Singles.sLive>();

            try
            {
                var query = from e in db.Live
                            select new
                            {
                                e.idLive,
                                e.TiempoTranscurrido
                            };
                foreach (var i in query)
                {
                    Singles.sLive e = new Singles.sLive();
                    e.idLive = i.idLive;
                    e.TiempoTranscurrido = i.TiempoTranscurrido;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sLive>(); }
        }

        public List<Singles.sLive> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLive> lList = new List<Singles.sLive>();

            try
            {
                var query = from l in db.Live
                            where (l.idLive.ToString().Contains(searchStr) ||
                                l.TiempoTranscurrido.ToString().Contains(searchStr))
                            select new
                            {
                                l.idLive,
                                l.TiempoTranscurrido,
                            };

                foreach (var i in query)
                {
                    Singles.sLive l = new Singles.sLive();
                    l.idLive = i.idLive;
                    l.TiempoTranscurrido = i.TiempoTranscurrido;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sLive>(); }
        }

        public List<Singles.sLive> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLive> lList = new List<Singles.sLive>();

            try
            {
                var query = from l in db.Live
                            select new
                            {
                                l.idLive,
                                l.TiempoTranscurrido,
                            };

                foreach (var i in query)
                {
                    Singles.sLive l = new Singles.sLive();
                    l.idLive = i.idLive;
                    l.TiempoTranscurrido = i.TiempoTranscurrido;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sLive>(); }
        }

        public List<Singles.sLive> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLive> lList = new List<Singles.sLive>();

            try
            {
                var query = from l in db.Live
                            where (l.idLive.ToString().Contains(searchStr) ||
                               l.TiempoTranscurrido.ToString().Contains(searchStr))
                            select new
                            {
                                l.idLive,
                                l.TiempoTranscurrido,
                            };

                foreach (var i in query)
                {
                    Singles.sLive l = new Singles.sLive();
                    l.idLive = i.idLive;
                    l.TiempoTranscurrido = i.TiempoTranscurrido;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sLive>(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cComentariosLive
    {
        public List<Singles.sComentariosLive> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sComentariosLive> eList = new List<Singles.sComentariosLive>();

            try
            {
                var query = from e in db.ComentariosLive
                            select new
                            {
                                e.idComentario,
                                e.idLive,
                                e.texto,
                                e.minuto
                            };
                foreach (var i in query)
                {
                    Singles.sComentariosLive e = new Singles.sComentariosLive();
                    e.idComentario = i.idComentario;
                    e.idLive = i.idLive;
                    e.texto = i.texto;
                    e.minuto = i.minuto;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sComentariosLive>(); }
        }

        public List<Singles.sComentariosLive> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sComentariosLive> lList = new List<Singles.sComentariosLive>();

            try
            {
                var query = from l in db.ComentariosLive
                            where (l.idComentario.ToString().Contains(searchStr) ||
                                l.idLive.ToString().Contains(searchStr) ||
                                l.texto.Contains(searchStr) ||
                                l.minuto.ToString().Contains(searchStr))
                            select new
                            {
                                l.idComentario,
                                l.idLive,
                                l.texto,
                                l.minuto
                            };

                foreach (var i in query)
                {
                    Singles.sComentariosLive l = new Singles.sComentariosLive();
                    l.idComentario = i.idComentario;
                    l.idLive = i.idLive;
                    l.texto = i.texto;
                    l.minuto = i.minuto;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sComentariosLive>(); }
        }

        public List<Singles.sComentariosLive> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sComentariosLive> lList = new List<Singles.sComentariosLive>();

            try
            {
                var query = from l in db.ComentariosLive
                            select new
                            {
                                l.idComentario,
                                l.idLive,
                                l.texto,
                                l.minuto
                            };

                foreach (var i in query)
                {
                    Singles.sComentariosLive l = new Singles.sComentariosLive();
                    l.idComentario = i.idComentario;
                    l.idLive = i.idLive;
                    l.texto = i.texto;
                    l.minuto = i.minuto;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sComentariosLive>(); }
        }

        public List<Singles.sComentariosLive> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sComentariosLive> lList = new List<Singles.sComentariosLive>();

            try
            {
                var query = from l in db.ComentariosLive
                            where (l.idComentario.ToString().Contains(searchStr) ||
                                l.idLive.ToString().Contains(searchStr) ||
                                l.texto.Contains(searchStr) ||
                                l.minuto.ToString().Contains(searchStr))
                            select new
                            {
                                l.idComentario,
                                l.idLive,
                                l.texto,
                                l.minuto
                            };

                foreach (var i in query)
                {
                    Singles.sComentariosLive l = new Singles.sComentariosLive();
                    l.idComentario = i.idComentario;
                    l.idLive = i.idLive;
                    l.texto = i.texto;
                    l.minuto = i.minuto;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sComentariosLive>(); }
        }

    }
}

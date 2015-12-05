using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cSancionesJugador
    {
        public List<Singles.sSancionesJugador> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSancionesJugador> eList = new List<Singles.sSancionesJugador>();

            try
            {
                var query = from e in db.SancionesJugador
                            select new
                            {
                                e.idSancionJugador,
                                e.idJugador,
                                e.idCategoria_Sancion,
                                e.multa,
                                e.Descripcion,
                                e.idArbitro
                            };
                foreach (var i in query)
                {
                    Singles.sSancionesJugador e = new Singles.sSancionesJugador();
                    e.idSancionJugador = i.idSancionJugador;
                    e.idJugador = i.idJugador;
                    e.idCategoria_Sancion = i.idCategoria_Sancion;
                    e.multa = i.multa;
                    e.Descripcion = i.Descripcion;
                    e.idArbitro = i.idArbitro;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sSancionesJugador>(); }
        }
        public List<Singles.sSancionesJugador> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSancionesJugador> lList = new List<Singles.sSancionesJugador>();

            try
            {
                var query = from l in db.SancionesJugador
                            where (l.idSancionJugador.ToString().Contains(searchStr) ||
                                l.idJugador.ToString().Contains(searchStr) ||
                                l.idCategoria_Sancion.ToString().Contains(searchStr) ||
                                 l.multa.ToString().Contains(searchStr) ||
                                  l.Descripcion.Contains(searchStr) ||
                                l.idArbitro.ToString().Contains(searchStr))
                            select new
                            {
                                l.idSancionJugador,
                                l.idJugador,
                                l.idCategoria_Sancion,
                                l.multa,
                                l.Descripcion,
                                l.idArbitro
                            };

                foreach (var i in query)
                {
                    Singles.sSancionesJugador l = new Singles.sSancionesJugador();
                    l.idSancionJugador = i.idSancionJugador;
                    l.idJugador = i.idJugador;
                    l.idCategoria_Sancion = i.idCategoria_Sancion;
                    l.multa = i.multa;
                    l.Descripcion = i.Descripcion;
                    l.idArbitro = i.idArbitro;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sSancionesJugador>(); }
        }

        public List<Singles.sSancionesJugador> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSancionesJugador> lList = new List<Singles.sSancionesJugador>();

            try
            {
                var query = from l in db.SancionesJugador
                            select new
                            {
                                l.idSancionJugador,
                                l.idJugador,
                                l.idCategoria_Sancion,
                                l.multa,
                                l.Descripcion,
                                l.idArbitro
                            };

                foreach (var i in query)
                {
                    Singles.sSancionesJugador l = new Singles.sSancionesJugador();
                    l.idSancionJugador = i.idSancionJugador;
                    l.idJugador = i.idJugador;
                    l.idCategoria_Sancion = i.idCategoria_Sancion;
                    l.multa = i.multa;
                    l.Descripcion = i.Descripcion;
                    l.idArbitro = i.idArbitro;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sSancionesJugador>(); }
        }

        public List<Singles.sSancionesJugador> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSancionesJugador> lList = new List<Singles.sSancionesJugador>();

            try
            {
                var query = from l in db.SancionesJugador
                            where (l.idSancionJugador.ToString().Contains(searchStr) ||
                                l.idJugador.ToString().Contains(searchStr) ||
                                l.idCategoria_Sancion.ToString().Contains(searchStr) ||
                                 l.multa.ToString().Contains(searchStr) ||
                                  l.Descripcion.Contains(searchStr) ||
                                l.idArbitro.ToString().Contains(searchStr))
                            select new
                            {
                                l.idSancionJugador,
                                l.idJugador,
                                l.idCategoria_Sancion,
                                l.multa,
                                l.Descripcion,
                                l.idArbitro
                            };

                foreach (var i in query)
                {
                    Singles.sSancionesJugador l = new Singles.sSancionesJugador();
                    l.idSancionJugador = i.idSancionJugador;
                    l.idJugador = i.idJugador;
                    l.idCategoria_Sancion = i.idCategoria_Sancion;
                    l.multa = i.multa;
                    l.Descripcion = i.Descripcion;
                    l.idArbitro = i.idArbitro;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sSancionesJugador>(); }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cPartidos
    {
        public List<Singles.sPartidos> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sPartidos> eList = new List<Singles.sPartidos>();

            try
            {
                var query = from e in db.Partidos
                            select new
                            {
                                e.idPartido,
                                e.idLiga,
                                e.idEquipoLocal,
                                e.idEquipoVisitante,
                                e.Date,
                                e.idCampo,
                                e.idLive,
                                e.idArbitro,
                                e.isJugado
                            };
                foreach (var i in query)
                {
                    Singles.sPartidos e = new Singles.sPartidos();
                    e.idPartido = i.idPartido;
                    e.idLiga = i.idLiga;
                    e.idEquipoLocal = i.idEquipoLocal;
                    e.idEquipoVisitante = i.idEquipoVisitante;
                    e.Date = i.Date;
                    e.idLive = i.idLive;
                    e.idArbitro = i.idArbitro;
                    e.isJugado = i.isJugado;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sPartidos>(); }
        }
        public List<Singles.sPartidos> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sPartidos> lList = new List<Singles.sPartidos>();

            try
            {
                var query = from l in db.Partidos
                            where (l.idPartido.ToString().Contains(searchStr) ||
                                l.idEquipoLocal.ToString().Contains(searchStr) ||
                                l.idEquipoVisitante.ToString().Contains(searchStr) ||
                                l.Date.ToString().Contains(searchStr) ||
                                l.idLive.ToString().Contains(searchStr) ||
                                    l.idArbitro.ToString().Contains(searchStr))

                            select new
                            {
                                l.idPartido,
                                l.idEquipoLocal,
                                l.idEquipoVisitante,
                                l.Date,
                                l.idLive,
                                l.idArbitro,
                                l.isJugado
                            };

                foreach (var i in query)
                {
                    Singles.sPartidos l = new Singles.sPartidos();
                    l.idPartido = i.idPartido;
                    l.idEquipoLocal = i.idEquipoLocal;
                    l.idEquipoVisitante = i.idEquipoVisitante;
                    l.Date = i.Date;
                    l.idLive = i.idLive;
                    l.idArbitro = i.idArbitro;
                    l.isJugado = i.isJugado;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sPartidos>(); }
        }

        public List<Singles.sPartidos> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sPartidos> lList = new List<Singles.sPartidos>();

            try
            {
                var query = from l in db.Partidos
                            select new
                            {
                                l.idPartido,
                                l.idEquipoLocal,
                                l.idEquipoVisitante,
                                l.Date,
                                l.idLive,
                                l.idArbitro,
                                l.isJugado,
                            };

                foreach (var i in query)
                {
                    Singles.sPartidos l = new Singles.sPartidos();
                    l.idPartido = i.idPartido;
                    l.idEquipoLocal = i.idEquipoLocal;
                    l.idEquipoVisitante = i.idEquipoVisitante;
                    l.Date = i.Date;
                    l.idLive = i.idLive;
                    l.idArbitro = i.idArbitro;
                    l.isJugado = i.isJugado;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sPartidos>(); }
        }

        public List<Singles.sPartidos> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sPartidos> lList = new List<Singles.sPartidos>();

            try
            {
                var query = from l in db.Partidos
                            where (l.idPartido.ToString().Contains(searchStr) ||
                                l.idEquipoLocal.ToString().Contains(searchStr) ||
                                l.idEquipoVisitante.ToString().Contains(searchStr) ||
                                l.Date.ToString().Contains(searchStr) ||
                                l.idLive.ToString().Contains(searchStr) ||
                                    l.idArbitro.ToString().Contains(searchStr))
                            select new
                            {
                                l.idPartido,
                                l.idEquipoLocal,
                                l.idEquipoVisitante,
                                l.Date,
                                l.idLive,
                                l.idArbitro,
                                l.isJugado
                            };

                foreach (var i in query)
                {
                    Singles.sPartidos l = new Singles.sPartidos();
                    l.idPartido = i.idPartido;
                    l.idEquipoLocal = i.idEquipoLocal;
                    l.idEquipoVisitante = i.idEquipoVisitante;
                    l.Date = i.Date;
                    l.idLive = i.idLive;
                    l.idArbitro = i.idArbitro;
                    l.isJugado = i.isJugado;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sPartidos>(); }
        }

        public IEnumerable<sPartidos> List(long idLiga)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sPartidos>();

            try
            {
                var query = from r in db.Partidos
                            where r.idLiga == idLiga
                            where r.isJugado == false
                            orderby r.Date
                            select r;


                foreach (var i in query)
                {
                    var item = new sPartidos();

                    item.idPartido = i.idPartido;
                    item.idLiga = i.idLiga;
                    item.idEquipoLocal = i.idEquipoLocal;
                    item.idEquipoVisitante = i.idEquipoVisitante;
                    item.Date = i.Date;
                    item.idCampo = i.idCampo;
                    item.idLive = i.idLive;
                    item.idArbitro = i.idArbitro;
                    item.nombreLocal = i.Equipos.Nombre;
                    item.nombreVisitante = i.Equipos1.Nombre;
                    item.nombreCampo = i.Campos.Nombre;
                    item.nombreArbitro = i.Arbitros.Nombre;
                    item.isJugado = i.isJugado;

                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                list = new List<sPartidos>();
            }

            return list;
        }

        public IEnumerable<sPartidos> ListResultados(long idLiga)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sPartidos>();

            try
            {
                var query = from r in db.Partidos
                            where r.idLiga == idLiga
                            where r.isJugado == true
                            orderby r.Date
                            select r;


                foreach (var i in query)
                {
                    var item = new sPartidos();

                    item.idPartido = i.idPartido;
                    item.idLiga = i.idLiga;
                    item.idEquipoLocal = i.idEquipoLocal;
                    item.idEquipoVisitante = i.idEquipoVisitante;
                    item.Date = i.Date;
                    item.idCampo = i.idCampo;
                    item.idLive = i.idLive;
                    item.idArbitro = i.idArbitro;
                    item.nombreLocal = i.Equipos.Nombre;
                    item.nombreVisitante = i.Equipos1.Nombre;
                    item.nombreCampo = i.Campos.Nombre;
                    item.nombreArbitro = i.Arbitros.Nombre;
                    item.isJugado = i.isJugado;

                    string resultado = "";
                    var queryResultadoLocal = from r in db.EstadisticasPartidos
                                         where r.idPartido == i.idPartido
                                         where r.idEquipo == i.idEquipoLocal                                             
                                         select r;
                    foreach (var p in queryResultadoLocal)
                    {
                        int? total = (p.Ensayos * 5 + p.Conversiones * 2 + p.GolpesCastigo * 3 + p.Drops * 3);
                        resultado = "" + total;
                    }
                    var queryResultadoVisitante = from r in db.EstadisticasPartidos
                                              where r.idPartido == i.idPartido
                                              where r.idEquipo == i.idEquipoVisitante
                                              select r;
                    foreach (var p in queryResultadoVisitante)
                    {
                        int? total = (p.Ensayos * 5 + p.Conversiones * 2 + p.GolpesCastigo * 3 + p.Drops * 3);
                        resultado = resultado + " - " + total;
                    }
                    item.resultado = resultado;

                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                list = new List<sPartidos>();
            }

            return list;
        }

        public IEnumerable<sPartidos> listaSinJugar()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sPartidos>();

            try
            {
                var query = from r in db.Partidos
                            where r.isJugado == false
                            where r.Date <= DateTime.Now
                            where r.idLive == null
                            orderby r.Date
                            select r;


                foreach (var i in query)
                {
                    var item = new sPartidos();

                    item.idPartido = i.idPartido;
                    item.idLiga = i.idLiga;
                    item.idEquipoLocal = i.idEquipoLocal;
                    item.idEquipoVisitante = i.idEquipoVisitante;
                    item.Date = i.Date;
                    item.idCampo = i.idCampo;
                    item.idLive = i.idLive;
                    item.idArbitro = i.idArbitro;
                    item.nombreLocal = i.Equipos.Nombre;
                    item.nombreVisitante = i.Equipos1.Nombre;
                    item.nombreCampo = i.Campos.Nombre;
                    item.nombreArbitro = i.Arbitros.Nombre;
                    item.isJugado = i.isJugado;
                    item.nombreLiga = i.Ligas.nombre;

                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                list = new List<sPartidos>();
            }

            return list;
        }

        public IEnumerable<sPartidos> listaConLive()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sPartidos>();

            try
            {
                var query = from r in db.Partidos
                            where r.idLive != null
                            where r.isJugado == false
                            orderby r.Date
                            select r;


                foreach (var i in query)
                {
                    var item = new sPartidos();

                    item.idPartido = i.idPartido;
                    item.idLiga = i.idLiga;
                    item.idEquipoLocal = i.idEquipoLocal;
                    item.idEquipoVisitante = i.idEquipoVisitante;
                    item.Date = i.Date;
                    item.idCampo = i.idCampo;
                    item.idLive = i.idLive;
                    item.idArbitro = i.idArbitro;
                    item.nombreLocal = i.Equipos.Nombre;
                    item.nombreVisitante = i.Equipos1.Nombre;
                    item.nombreCampo = i.Campos.Nombre;
                    item.nombreArbitro = i.Arbitros.Nombre;
                    item.isJugado = i.isJugado;
                    item.nombreLiga = i.Ligas.nombre;

                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                list = new List<sPartidos>();
            }

            return list;
        }
        
    }
}

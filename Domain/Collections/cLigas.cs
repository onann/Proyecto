using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cLigas
    {
        public List<Singles.sLigas> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLigas> lList = new List<Singles.sLigas>();

            try
            {
                var query = from l in db.Ligas
                            select new
                            {
                                l.idLiga,
                                l.nombre,
                                l.idCategoriaLiga,                             
                            };


                foreach (var i in query)
                {
                    Singles.sLigas l = new Singles.sLigas();
                    l.idLiga = i.idLiga;
                    l.nombre = i.nombre;
                    lList.Add(l);
                }
                return lList;
            }
            catch { return new List<Singles.sLigas>(); }
        }
        public List<Singles.sLigas> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLigas> lList = new List<Singles.sLigas>();

            try
            {
                var query = from l in db.Ligas
                            where l.idLiga.ToString().Contains(searchStr) ||
                                l.nombre.Contains(searchStr) ||
                                l.idCategoriaLiga.ToString().Contains(searchStr)
                            select new
                            {
                                l.idLiga,
                                l.nombre,
                                l.idCategoriaLiga
                            };

                foreach (var i in query)
                {
                    Singles.sLigas l = new Singles.sLigas();
                    l.idLiga = i.idLiga;
                    l.nombre = i.nombre;
                    l.idCategoriaLiga = i.idCategoriaLiga;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sLigas>(); }
        }

        public List<Singles.sLigas> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLigas> lList = new List<Singles.sLigas>();

            try
            {
                var query = from l in db.Ligas
                            select new
                            {
                                l.idLiga,
                                l.nombre,
                                l.idCategoriaLiga,
                            };

                foreach (var i in query)
                {
                    Singles.sLigas l = new Singles.sLigas();
                    l.idLiga = i.idLiga;
                    l.nombre = i.nombre;
                    l.idCategoriaLiga = i.idCategoriaLiga;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sLigas>(); }
        }

        public List<Singles.sLigas> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sLigas> lList = new List<Singles.sLigas>();

            try
            {
                var query = from l in db.Ligas
                            where l.idLiga.ToString().Contains(searchStr) ||
                                l.nombre.Contains(searchStr) ||
                                l.idCategoriaLiga.ToString().Contains(searchStr)
                            select new
                            {
                                l.idLiga,
                                l.nombre,
                                l.idCategoriaLiga
                            };

                foreach (var i in query)
                {
                    Singles.sLigas l = new Singles.sLigas();
                    l.idLiga = i.idLiga;
                    l.nombre = i.nombre;
                    l.idCategoriaLiga = i.idCategoriaLiga;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sLigas>(); }
        }

        public IEnumerable<sLigas> List(string search, bool showDeleted)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sLigas>();

            try
            {
                var query = from l in db.Ligas
                            select l;

                if (!string.IsNullOrEmpty(search)) query = query.Where(x => x.nombre.Contains(search));

                //if (!showDeleted) query = query.Where(x => x.Status != (byte)Definitions.eCoreStatus.Deleted);

                foreach (var i in query)
                {
                    var item = new sLigas();

                    item.idLiga = i.idLiga;
                    item.idCategoriaLiga = i.idCategoriaLiga;
                    item.nombre = i.nombre;
                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                list = new List<sLigas>();
            }

            return list;
        }

        public IEnumerable<sEquipos> List(long idLiga)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sEquipos>();

            try
            {
                var query = from r in db.Equipos
                            where r.idLiga == idLiga
                            orderby r.Puntos descending
                            select r;


                foreach (var i in query)
                {
                    var item = new sEquipos();

                    item.idEquipo = i.idEquipo;
                    item.idClub = i.idClub;
                    item.Nombre = i.Nombre;
                    item.idLiga = i.idLiga;
                    item.Puntos = i.Puntos;
                    item.Partidos_Jugados = i.Partidos_Jugados;
                    item.Partidos_Ganados = i.Partidos_Ganados;
                    item.Partidos_Perdidos = i.Partidos_Perdidos;
                    item.Partidos_Empatados = i.Partidos_Empatados;
                    item.Puntos_Encajados = i.Puntos_Encajados;
                    item.Puntos_Anotados = i.Puntos_Anotados;

                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                list = new List<sEquipos>();
            }

            return list;
        }
    }



}

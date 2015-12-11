using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cEquipos
    {       

        public List<Singles.sEquipos> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEquipos> eList = new List<Singles.sEquipos>();

            try
            {
                var query = from e in db.Equipos
                            select new
                            {
                                e.idEquipo,
                                e.idClub,
                                e.Nombre,
                                e.idLiga,
                                e.Puntos,
                                e.Partidos_Jugados,
                                e.Partidos_Ganados,
                                e.Partidos_Perdidos,
                                e.Partidos_Empatados,
                                e.Puntos_Encajados,
                                e.Puntos_Anotados,                                
                                e.Ligas.nombre,
                                nombreclub = e.Clubes.Nombre
                            };
                foreach (var i in query)
                {
                    Singles.sEquipos e = new Singles.sEquipos();
                    e.idEquipo = i.idEquipo;
                    e.idClub = i.idClub;
                    e.Nombre = i.Nombre;
                    e.idLiga = i.idLiga;
                    e.Puntos = i.Puntos;
                    e.Partidos_Jugados = i.Partidos_Jugados;
                    e.Partidos_Ganados = i.Partidos_Ganados;
                    e.Partidos_Perdidos = i.Partidos_Perdidos;
                    e.Partidos_Empatados = i.Partidos_Empatados;
                    e.Puntos_Encajados = i.Puntos_Encajados;
                    e.Puntos_Anotados = i.Puntos_Anotados;
                    e.nombreLiga = i.nombre;
                    e.nombreClub = i.nombreclub;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sEquipos>(); }
        }

        public List<Singles.sEquipos> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEquipos> lList = new List<Singles.sEquipos>();

            try
            {
                var query = from l in db.Equipos
                            where (l.idEquipo.ToString().Contains(searchStr) ||
                                l.idClub.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.idLiga.ToString().Contains(searchStr) ||
                                l.Puntos.ToString().Contains(searchStr) ||
                                l.Partidos_Jugados.ToString().Contains(searchStr) ||
                                        l.Partidos_Ganados.ToString().Contains(searchStr) ||
                                            l.Partidos_Perdidos.ToString().Contains(searchStr) ||
                                                l.Partidos_Empatados.ToString().Contains(searchStr) ||
                                                    l.Puntos_Encajados.ToString().Contains(searchStr) ||
                                                        l.Puntos_Anotados.ToString().Contains(searchStr))
                            select new
                            {
                                l.idEquipo,
                                l.idClub,
                                l.Nombre,
                                l.idLiga,
                                l.Puntos,
                                l.Partidos_Jugados,
                                l.Partidos_Ganados,
                                l.Partidos_Perdidos,
                                l.Partidos_Empatados,
                                l.Puntos_Encajados,
                                l.Puntos_Anotados,
                                l.Ligas.nombre,
                                nombreclub = l.Clubes.Nombre
                            };

                foreach (var i in query)
                {
                    Singles.sEquipos e = new Singles.sEquipos();
                    e.idEquipo = i.idEquipo;
                    e.idClub = i.idClub;
                    e.Nombre = i.Nombre;
                    e.idLiga = i.idLiga;
                    e.Puntos = i.Puntos;
                    e.Partidos_Jugados = i.Partidos_Jugados;
                    e.Partidos_Ganados = i.Partidos_Ganados;
                    e.Partidos_Perdidos = i.Partidos_Perdidos;
                    e.Partidos_Empatados = i.Partidos_Empatados;
                    e.Puntos_Encajados = i.Puntos_Encajados;
                    e.Puntos_Anotados = i.Puntos_Anotados;
                    e.nombreLiga = i.nombre;
                    e.nombreClub = i.nombreclub;

                    lList.Add(e);
                }

                return lList;
            }
            catch { return new List<Singles.sEquipos>(); }
        }

        public List<Singles.sEquipos> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEquipos> lList = new List<Singles.sEquipos>();

            try
            {
                var query = from l in db.Equipos
                            select new
                            {
                                l.idEquipo,
                                l.idClub,
                                l.Nombre,
                                l.idLiga,
                                l.Puntos,
                                l.Partidos_Jugados,
                                l.Partidos_Ganados,
                                l.Partidos_Perdidos,
                                l.Partidos_Empatados,
                                l.Puntos_Encajados,
                                l.Puntos_Anotados
                            };

                foreach (var i in query)
                {
                    Singles.sEquipos e = new Singles.sEquipos();
                    e.idEquipo = i.idEquipo;
                    e.idClub = i.idClub;
                    e.Nombre = i.Nombre;
                    e.idLiga = i.idLiga;
                    e.Puntos = i.Puntos;
                    e.Partidos_Jugados = i.Partidos_Jugados;
                    e.Partidos_Ganados = i.Partidos_Ganados;
                    e.Partidos_Perdidos = i.Partidos_Perdidos;
                    e.Partidos_Empatados = i.Partidos_Empatados;
                    e.Puntos_Encajados = i.Puntos_Encajados;
                    e.Puntos_Anotados = i.Puntos_Anotados;

                    lList.Add(e);
                }

                return lList;
            }
            catch { return new List<Singles.sEquipos>(); }
        }

        public List<Singles.sEquipos> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEquipos> lList = new List<Singles.sEquipos>();

            try
            {
                var query = from l in db.Equipos
                            where (l.idEquipo.ToString().Contains(searchStr) ||
                                l.idClub.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.idLiga.ToString().Contains(searchStr) ||
                                l.Puntos.ToString().Contains(searchStr) ||
                                l.Partidos_Jugados.ToString().Contains(searchStr) ||
                                        l.Partidos_Ganados.ToString().Contains(searchStr) ||
                                            l.Partidos_Perdidos.ToString().Contains(searchStr) ||
                                                l.Partidos_Empatados.ToString().Contains(searchStr) ||
                                                    l.Puntos_Encajados.ToString().Contains(searchStr) ||
                                                        l.Puntos_Anotados.ToString().Contains(searchStr))
                            select new
                            {
                                l.idEquipo,
                                l.idClub,
                                l.Nombre,
                                l.idLiga,
                                l.Puntos,
                                l.Partidos_Jugados,
                                l.Partidos_Ganados,
                                l.Partidos_Perdidos,
                                l.Partidos_Empatados,
                                l.Puntos_Encajados,
                                l.Puntos_Anotados
                            };

                foreach (var i in query)
                {
                    Singles.sEquipos e = new Singles.sEquipos();
                    e.idEquipo = i.idEquipo;
                    e.idClub = i.idClub;
                    e.Nombre = i.Nombre;
                    e.idLiga = i.idLiga;
                    e.Puntos = i.Puntos;
                    e.Partidos_Jugados = i.Partidos_Jugados;
                    e.Partidos_Ganados = i.Partidos_Ganados;
                    e.Partidos_Perdidos = i.Partidos_Perdidos;
                    e.Partidos_Empatados = i.Partidos_Empatados;
                    e.Puntos_Encajados = i.Puntos_Encajados;
                    e.Puntos_Anotados = i.Puntos_Anotados;

                    lList.Add(e);
                }

                return lList;
            }
            catch { return new List<Singles.sEquipos>(); }
        }

        public IEnumerable<sEquipos> List(int idLiga)
        {
            List<sEquipos> list = new List<sEquipos>();
            ProyectoEntities1 db = new ProyectoEntities1();
            try
            {
                var query = from e in db.Equipos
                            where e.idLiga == idLiga
                            select e;

                foreach (var i in query)
                {
                    sEquipos item = new sEquipos();
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

                return list;
            }
            catch (Exception ex)
            {
                return new List<sEquipos>();
            }

        }        

       
    }
}

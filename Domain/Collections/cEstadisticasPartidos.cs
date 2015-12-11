using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cEstadisticasPartidos
    {
        public List<Singles.sEstadisticasPartidos> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEstadisticasPartidos> eList = new List<Singles.sEstadisticasPartidos>();

            try
            {
                var query = from l in db.EstadisticasPartidos
                            select new
                            {
                                l.idEstadistica_Partido,
                                l.idPartido,
                                l.idEquipo,
                                l.Ensayos,
                                l.Conversiones,
                                l.GolpesCastigo,
                                l.Drops,
                                l.TarjetasAmarillas,
                                l.TarjetasRojas,
                                l.Marcador

                            };


                foreach (var i in query)
                {
                    Singles.sEstadisticasPartidos l = new Singles.sEstadisticasPartidos();
                    l.idEstadistica_Partido = i.idEstadistica_Partido;
                    l.idPartido = i.idPartido;
                    l.idEquipo = i.idEquipo;
                    l.Ensayos = i.Ensayos;
                    l.Conversiones = i.Conversiones;
                    l.GolpesCastigo = i.GolpesCastigo;
                    l.Drops = i.Drops;
                    l.TarjetasAmarillas = i.TarjetasAmarillas;
                    l.TarjetasRojas = i.TarjetasRojas;
                    l.marcador = i.Marcador;
                    eList.Add(l);
                }
                return eList;
            }
            catch { return new List<Singles.sEstadisticasPartidos>(); }
        }

        public List<Singles.sEstadisticasPartidos> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEstadisticasPartidos> lList = new List<Singles.sEstadisticasPartidos>();

            try
            {
                var query = from l in db.EstadisticasPartidos
                            where (l.idEstadistica_Partido.ToString().Contains(searchStr) ||
                                l.idEquipo.ToString().Contains(searchStr) ||
                                l.Ensayos.ToString().Contains(searchStr) ||
                                l.Conversiones.ToString().Contains(searchStr) ||
                                 l.GolpesCastigo.ToString().Contains(searchStr) ||
                                      l.Drops.ToString().Contains(searchStr) ||
                                       l.TarjetasAmarillas.ToString().Contains(searchStr) ||
                                        l.TarjetasRojas.ToString().Contains(searchStr) ||
                                        l.Marcador.ToString().Contains(searchStr))

                            select new
                            {
                                l.idEstadistica_Partido,
                                l.idPartido,
                                l.idEquipo,
                                l.Ensayos,
                                l.Conversiones,
                                l.GolpesCastigo,
                                l.Drops,
                                l.TarjetasAmarillas,
                                l.TarjetasRojas,
                                l.Marcador
                            };

                foreach (var i in query)
                {
                    Singles.sEstadisticasPartidos l = new Singles.sEstadisticasPartidos();
                    l.idEstadistica_Partido = i.idEstadistica_Partido;
                    l.idPartido = i.idPartido;
                    l.idEquipo = i.idEquipo;
                    l.Ensayos = i.Ensayos;
                    l.Conversiones = i.Conversiones;
                    l.GolpesCastigo = i.GolpesCastigo;
                    l.Drops = i.Drops;
                    l.TarjetasAmarillas = i.TarjetasAmarillas;
                    l.TarjetasRojas = i.TarjetasRojas;
                    l.marcador = i.Marcador;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sEstadisticasPartidos>(); }
        }

        public List<Singles.sEstadisticasPartidos> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEstadisticasPartidos> lList = new List<Singles.sEstadisticasPartidos>();

            try
            {
                var query = from l in db.EstadisticasPartidos
                            select new
                            {
                                l.idEstadistica_Partido,
                                l.idPartido,
                                l.idEquipo,
                                l.Ensayos,
                                l.Conversiones,
                                l.GolpesCastigo,
                                l.Drops,
                                l.TarjetasAmarillas,
                                l.TarjetasRojas,
                                l.Marcador
                            };

                foreach (var i in query)
                {
                    Singles.sEstadisticasPartidos l = new Singles.sEstadisticasPartidos();
                    l.idEstadistica_Partido = i.idEstadistica_Partido;
                    l.idPartido = i.idPartido;
                    l.idEquipo = i.idEquipo;
                    l.Ensayos = i.Ensayos;
                    l.Conversiones = i.Conversiones;
                    l.GolpesCastigo = i.GolpesCastigo;
                    l.Drops = i.Drops;
                    l.TarjetasAmarillas = i.TarjetasAmarillas;
                    l.TarjetasRojas = i.TarjetasRojas;
                    l.marcador = i.Marcador;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sEstadisticasPartidos>(); }
        }

        public List<Singles.sEstadisticasPartidos> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sEstadisticasPartidos> lList = new List<Singles.sEstadisticasPartidos>();

            try
            {
                var query = from l in db.EstadisticasPartidos
                            where (l.idEstadistica_Partido.ToString().Contains(searchStr) ||
                                l.idEquipo.ToString().Contains(searchStr) ||
                                l.Ensayos.ToString().Contains(searchStr) ||
                                l.Conversiones.ToString().Contains(searchStr) ||
                                 l.GolpesCastigo.ToString().Contains(searchStr) ||
                                      l.Drops.ToString().Contains(searchStr) ||
                                       l.TarjetasAmarillas.ToString().Contains(searchStr) ||
                                        l.TarjetasRojas.ToString().Contains(searchStr) ||
                                        l.Marcador.ToString().Contains(searchStr))

                            select new
                            {
                                l.idEstadistica_Partido,
                                l.idPartido,
                                l.idEquipo,
                                l.Ensayos,
                                l.Conversiones,
                                l.GolpesCastigo,
                                l.Drops,
                                l.TarjetasAmarillas,
                                l.TarjetasRojas,
                                l.Marcador
                            };

                foreach (var i in query)
                {
                    Singles.sEstadisticasPartidos l = new Singles.sEstadisticasPartidos();
                    l.idEstadistica_Partido = i.idEstadistica_Partido;
                    l.idPartido = i.idPartido;
                    l.idEquipo = i.idEquipo;
                    l.Ensayos = i.Ensayos;
                    l.Conversiones = i.Conversiones;
                    l.GolpesCastigo = i.GolpesCastigo;
                    l.Drops = i.Drops;
                    l.TarjetasAmarillas = i.TarjetasAmarillas;
                    l.TarjetasRojas = i.TarjetasRojas;
                    l.marcador = i.Marcador;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sEstadisticasPartidos>(); }
        }

        public IEnumerable<sEstadisticasPartidos> estadisticasEquipo(long idEquipo)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sEstadisticasPartidos>();

            try
            {
                var query2 = db.EstadisticasPartidos
             .Where(r => r.idEquipo == idEquipo)
             .GroupBy(r => r.idPartido)
             .Select(g =>
                 new
                 {
                     Ensayos = g.Sum(s => s.Ensayos),
                     Conversiones = g.Sum(s => s.Conversiones),
                     Drops = g.Sum(s => s.Drops),
                     GolpesCastigo = g.Sum(s => s.GolpesCastigo),
                     TarjetasRojas = g.Sum(s => s.TarjetasRojas),
                     TarjetasAmarillas = g.Sum(s => s.TarjetasAmarillas)
                 });

                var item = new sEstadisticasPartidos();
                foreach (var i in query2)
                {
                    item.marcador = (int)((i.Ensayos * 5) + (i.Conversiones * 2) + (i.Drops * 3) + (i.GolpesCastigo * 3));
                    item.totalPuntos = ((i.Ensayos * 5) + (i.Conversiones * 2) + (i.Drops * 3) + (i.GolpesCastigo * 3)) ?? 0;
                    item.Ensayos = i.Ensayos ?? 0;
                    item.Conversiones = i.Conversiones ?? 0;
                    item.Drops = i.Drops ?? 0;
                    item.GolpesCastigo = i.GolpesCastigo ?? 0;
                    item.TarjetasAmarillas = i.TarjetasAmarillas ?? 0;
                    item.TarjetasRojas = i.TarjetasRojas ?? 0;

                    
                }
                list.Add(item);
            }
            catch (Exception ex)
            {
                list = new List<sEstadisticasPartidos>();
            }

            return list;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cSanciones_Equipo
    {
        public List<Singles.sSanciones_Equipo> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSanciones_Equipo> sList = new List<Singles.sSanciones_Equipo>();

            try
            {
                var query = from l in db.Sanciones_Equipo
                            select new
                            {
                                l.idSancion_Equipo,
                                l.descripcion,
                                l.multa,
                                l.idCategoria_Sancion,
                                l.idEquipo
                            };


                foreach (var i in query)
                {
                    Singles.sSanciones_Equipo l = new Singles.sSanciones_Equipo();
                    l.idSancion_Equipo = i.idSancion_Equipo;
                    l.descripcion = i.descripcion;
                    l.multa = i.multa;
                    l.idCategoria_Sancion = i.idCategoria_Sancion;
                    l.idEquipo = i.idEquipo;
                    sList.Add(l);
                }
                return sList;
            }
            catch { return new List<Singles.sSanciones_Equipo>(); }
        }

        public List<Singles.sSanciones_Equipo> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSanciones_Equipo> lList = new List<Singles.sSanciones_Equipo>();

            try
            {
                var query = from l in db.Sanciones_Equipo
                            where (l.idSancion_Equipo.ToString().Contains(searchStr) ||
                                l.descripcion.Contains(searchStr) ||
                                l.multa.ToString().Contains(searchStr) ||
                                l.idCategoria_Sancion.ToString().Contains(searchStr) ||
                                l.idEquipo.ToString().Contains(searchStr))
                            select new
                            {
                                l.idSancion_Equipo,
                                l.descripcion,
                                l.multa,
                                l.idCategoria_Sancion,
                                l.idEquipo
                            };

                foreach (var i in query)
                {
                    Singles.sSanciones_Equipo l = new Singles.sSanciones_Equipo();
                    l.idSancion_Equipo = i.idSancion_Equipo;
                    l.descripcion = i.descripcion;
                    l.multa = i.multa;
                    l.idCategoria_Sancion = i.idCategoria_Sancion;
                    l.idEquipo = i.idEquipo;
                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sSanciones_Equipo>(); }
        }

        public List<Singles.sSanciones_Equipo> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSanciones_Equipo> lList = new List<Singles.sSanciones_Equipo>();

            try
            {
                var query = from l in db.Sanciones_Equipo
                            select new
                            {
                                l.idSancion_Equipo,
                                l.descripcion,
                                l.multa,
                                l.idCategoria_Sancion,
                                l.idEquipo
                            };

                foreach (var i in query)
                {
                    Singles.sSanciones_Equipo l = new Singles.sSanciones_Equipo();
                    l.idSancion_Equipo = i.idSancion_Equipo;
                    l.descripcion = i.descripcion;
                    l.multa = i.multa;
                    l.idCategoria_Sancion = i.idCategoria_Sancion;
                    l.idEquipo = i.idEquipo;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sSanciones_Equipo>(); }
        }

        public List<Singles.sSanciones_Equipo> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sSanciones_Equipo> lList = new List<Singles.sSanciones_Equipo>();

            try
            {
                var query = from l in db.Sanciones_Equipo
                            where (l.idSancion_Equipo.ToString().Contains(searchStr) ||
                                 l.descripcion.Contains(searchStr) ||
                                 l.multa.ToString().Contains(searchStr) ||
                                 l.idCategoria_Sancion.ToString().Contains(searchStr) ||
                                 l.idEquipo.ToString().Contains(searchStr))
                            select new
                            {
                                l.idSancion_Equipo,
                                l.descripcion,
                                l.multa,
                                l.idCategoria_Sancion,
                                l.idEquipo
                            };

                foreach (var i in query)
                {
                    Singles.sSanciones_Equipo l = new Singles.sSanciones_Equipo();
                    l.idSancion_Equipo = i.idSancion_Equipo;
                    l.descripcion = i.descripcion;
                    l.multa = i.multa;
                    l.idCategoria_Sancion = i.idCategoria_Sancion;
                    l.idEquipo = i.idEquipo;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sSanciones_Equipo>(); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cCategoriasSanciones
    {
        public List<Singles.sCategoriasSanciones> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoriasSanciones> eList = new List<Singles.sCategoriasSanciones>();

            try
            {
                var query = from e in db.CategoriasSanciones
                            select new
                            {
                                e.idCategoriaSancion,
                                e.Descripcion,
                                e.Nombre
                            };
                foreach (var i in query)
                {
                    Singles.sCategoriasSanciones e = new Singles.sCategoriasSanciones();
                    e.idCategoriaSancion = i.idCategoriaSancion;
                    e.Descripcion = i.Descripcion;
                    e.Nombre = i.Nombre;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sCategoriasSanciones>(); }
        }
        public List<Singles.sCategoriasSanciones> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoriasSanciones> lList = new List<Singles.sCategoriasSanciones>();

            try
            {
                var query = from l in db.CategoriasSanciones
                            where (l.idCategoriaSancion.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Descripcion.Contains(searchStr))
                            select new
                            {
                                l.idCategoriaSancion,
                                l.Nombre,
                                l.Descripcion
                            };

                foreach (var i in query)
                {
                    Singles.sCategoriasSanciones l = new Singles.sCategoriasSanciones();
                    l.idCategoriaSancion = i.idCategoriaSancion;
                    l.Nombre = i.Nombre;
                    l.Descripcion = i.Descripcion;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCategoriasSanciones>(); }
        }

        public List<Singles.sCategoriasSanciones> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoriasSanciones> lList = new List<Singles.sCategoriasSanciones>();

            try
            {
                var query = from l in db.CategoriasSanciones
                            select new
                            {
                                l.idCategoriaSancion,
                                l.Nombre,
                                l.Descripcion
                            };

                foreach (var i in query)
                {
                    Singles.sCategoriasSanciones l = new Singles.sCategoriasSanciones();
                    l.idCategoriaSancion = i.idCategoriaSancion;
                    l.Nombre = i.Nombre;
                    l.Descripcion = i.Descripcion;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCategoriasSanciones>(); }
        }

        public List<Singles.sCategoriasSanciones> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoriasSanciones> lList = new List<Singles.sCategoriasSanciones>();

            try
            {
                var query = from l in db.CategoriasSanciones
                            where (l.idCategoriaSancion.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Descripcion.Contains(searchStr))
                            select new
                            {
                                l.idCategoriaSancion,
                                l.Nombre,
                                l.Descripcion
                            };

                foreach (var i in query)
                {
                    Singles.sCategoriasSanciones l = new Singles.sCategoriasSanciones();
                    l.idCategoriaSancion = i.idCategoriaSancion;
                    l.Nombre = i.Nombre;
                    l.Descripcion = i.Descripcion;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCategoriasSanciones>(); }
        }
    }
}

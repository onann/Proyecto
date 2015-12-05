using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cCategoria_Ligas
    {
        public List<Singles.sCategoria_Ligas> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoria_Ligas> cList = new List<Singles.sCategoria_Ligas>();

            try
            {
                var query = from l in db.Categoria_Ligas
                            select new
                            {
                                l.idCategoriaLiga,
                                l.NombreCategoria,
                            };


                foreach (var i in query)
                {
                    Singles.sCategoria_Ligas l = new Singles.sCategoria_Ligas();
                    l.idCategoriaLiga = i.idCategoriaLiga;
                    l.NombreCategoria = i.NombreCategoria;
                    cList.Add(l);
                }
                return cList;
            }
            catch { return new List<Singles.sCategoria_Ligas>(); }
        }

        public List<Singles.sCategoria_Ligas> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoria_Ligas> lList = new List<Singles.sCategoria_Ligas>();

            try
            {
                var query = from l in db.Categoria_Ligas
                            where (l.idCategoriaLiga.ToString().Contains(searchStr) ||
                                l.NombreCategoria.Contains(searchStr))

                            select new
                            {
                                l.idCategoriaLiga,
                                l.NombreCategoria
                            };

                foreach (var i in query)
                {
                    Singles.sCategoria_Ligas l = new Singles.sCategoria_Ligas();
                    l.idCategoriaLiga = i.idCategoriaLiga;
                    l.NombreCategoria = i.NombreCategoria;
                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCategoria_Ligas>(); }
        }

        public List<Singles.sCategoria_Ligas> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoria_Ligas> lList = new List<Singles.sCategoria_Ligas>();

            try
            {
                var query = from l in db.Categoria_Ligas
                            select new
                            {
                                l.idCategoriaLiga,
                                l.NombreCategoria
                            };

                foreach (var i in query)
                {
                    Singles.sCategoria_Ligas l = new Singles.sCategoria_Ligas();
                    l.idCategoriaLiga = i.idCategoriaLiga;
                    l.NombreCategoria = i.NombreCategoria;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCategoria_Ligas>(); }
        }

        public List<Singles.sCategoria_Ligas> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCategoria_Ligas> lList = new List<Singles.sCategoria_Ligas>();

            try
            {
                var query = from l in db.Categoria_Ligas
                            where (l.idCategoriaLiga.ToString().Contains(searchStr) ||
                                l.NombreCategoria.Contains(searchStr))
                            select new
                            {
                                l.idCategoriaLiga,
                                l.NombreCategoria
                            };

                foreach (var i in query)
                {
                    Singles.sCategoria_Ligas l = new Singles.sCategoria_Ligas();
                    l.idCategoriaLiga = i.idCategoriaLiga;
                    l.NombreCategoria = i.NombreCategoria;
                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCategoria_Ligas>(); }
        }
    }
}

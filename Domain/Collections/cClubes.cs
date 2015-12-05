using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cClubes
    {
        public List<Singles.sClubes> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sClubes> lList = new List<Singles.sClubes>();
            
            try
            {
                var query = from l in db.Clubes
                            select new
                            {
                                l.idClub,
                                l.Nombre,
                                l.Localidad,
                                l.Telefono,
                            };


                foreach (var i in query)
                {
                    Singles.sClubes l = new Singles.sClubes();
                    l.idClub = i.idClub;
                    l.Nombre = i.Nombre;
                    l.Localidad = i.Localidad;
                    l.Telefono = i.Telefono;
                    lList.Add(l);
                }
                return lList;
            }
            catch { return new List<Singles.sClubes>(); }
        }

        public List<Singles.sClubes> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sClubes> lList = new List<Singles.sClubes>();

            try
            {
                var query = from l in db.Clubes
                            where (l.idClub.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Localidad.Contains(searchStr) ||
                                l.Telefono.Contains(searchStr))
                            select new
                            {
                                l.idClub,
                                l.Nombre,
                                l.Localidad,
                                l.Telefono
                            };

                foreach (var i in query)
                {
                    Singles.sClubes l = new Singles.sClubes();
                    l.idClub = i.idClub;
                    l.Nombre = i.Nombre;
                    l.Localidad = i.Localidad;
                    l.Telefono = i.Telefono;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sClubes>(); }
        }

        public List<Singles.sClubes> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sClubes> lList = new List<Singles.sClubes>();

            try
            {
                var query = from l in db.Clubes
                            select new
                            {
                                l.idClub,
                                l.Nombre,
                                l.Localidad,
                                l.Telefono   
                            };

                foreach (var i in query)
                {
                    Singles.sClubes l = new Singles.sClubes();
                    l.idClub = i.idClub;
                    l.Nombre = i.Nombre;
                    l.Localidad = i.Localidad;
                    l.Telefono = i.Telefono;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sClubes>(); }
        }

        public List<Singles.sClubes> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sClubes> lList = new List<Singles.sClubes>();

            try
            {
                var query = from l in db.Clubes
                            where (l.idClub.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Localidad.Contains(searchStr) ||
                                l.Telefono.Contains(searchStr))
                            select new
                            {
                                l.idClub,
                                l.Nombre,
                                l.Localidad,
                                l.Telefono
                            };

                foreach (var i in query)
                {
                    Singles.sClubes l = new Singles.sClubes();
                    l.idClub = i.idClub;
                    l.Nombre = i.Nombre;
                    l.Localidad = i.Localidad;
                    l.Telefono = i.Telefono;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sClubes>(); }
        }
    }
}

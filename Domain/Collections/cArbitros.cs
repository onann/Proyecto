using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cArbitros
    {
        public List<Singles.sArbitros> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sArbitros> eList = new List<Singles.sArbitros>();

            try
            {
                var query = from e in db.Arbitros
                            select new
                            {
                                e.idArbitro,
                                e.Nombre,
                                e.Apellido1,
                                e.Apellido2,
                                e.Fecha_Nacimiento,
                                e.Partidos,
                                e.TarjetasAmarillas,
                                e.TarjetasRojas
                            };
                foreach (var i in query)
                {
                    Singles.sArbitros e = new Singles.sArbitros();
                    e.idArbitro = i.idArbitro;
                    e.Nombre = i.Nombre;
                    e.Apellido1 = i.Apellido1;
                    e.Apellido2 = i.Apellido2;
                    e.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    e.Partidos = i.Partidos ?? 0;
                    e.TarjetasAmarillas = i.TarjetasAmarillas ?? 0;    
                    e.TarjetasRojas = i.TarjetasRojas ?? 0;  
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sArbitros>(); }
        }

        public List<Singles.sArbitros> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sArbitros> lList = new List<Singles.sArbitros>();

            try
            {
                var query = from l in db.Arbitros
                            where (l.idArbitro.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Apellido1.Contains(searchStr) ||
                                l.Apellido2.Contains(searchStr)) ||
                                l.Fecha_Nacimiento.ToString().Contains(searchStr) ||
                                l.Partidos.ToString().Contains(searchStr) ||
                                l.TarjetasAmarillas.ToString().Contains(searchStr) ||
                                l.TarjetasRojas.ToString().Contains(searchStr)
                            select new
                            {
                                l.idArbitro,
                                l.Nombre,
                                l.Apellido1,
                                l.Apellido2,
                                l.Fecha_Nacimiento,
                                l.Partidos,
                                l.TarjetasAmarillas,
                                l.TarjetasRojas

                            };

                foreach (var i in query)
                {
                    Singles.sArbitros l = new Singles.sArbitros();
                    l.idArbitro = i.idArbitro;
                    l.Nombre = i.Nombre;
                    l.Apellido1 = i.Apellido1;
                    l.Apellido2 = i.Apellido2;
                    l.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    l.Partidos = i.Partidos ?? 0;
                    l.TarjetasAmarillas = i.TarjetasAmarillas ?? 0;
                    l.TarjetasRojas = i.TarjetasRojas ?? 0;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sArbitros>(); }
        }

        public List<Singles.sArbitros> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sArbitros> lList = new List<Singles.sArbitros>();

            try
            {
                var query = from l in db.Arbitros
                            select new
                            {
                                l.idArbitro,
                                l.Nombre,
                                l.Apellido1,
                                l.Apellido2,
                                l.Fecha_Nacimiento,
                                l.Partidos,
                                l.TarjetasAmarillas,
                                l.TarjetasRojas
                            };

                foreach (var i in query)
                {
                    Singles.sArbitros l = new Singles.sArbitros();
                    l.idArbitro = i.idArbitro;
                    l.Nombre = i.Nombre;
                    l.Apellido1 = i.Apellido1;
                    l.Apellido2 = i.Apellido2;
                    l.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    l.Partidos = i.Partidos ?? 0;
                    l.TarjetasAmarillas = i.TarjetasAmarillas ?? 0;
                    l.TarjetasRojas = i.TarjetasRojas ?? 0;
                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sArbitros>(); }
        }

        public List<Singles.sArbitros> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sArbitros> lList = new List<Singles.sArbitros>();

            try
            {
                var query = from l in db.Arbitros
                            where (l.idArbitro.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Apellido1.Contains(searchStr) ||
                                l.Apellido2.Contains(searchStr)) ||
                                l.Fecha_Nacimiento.ToString().Contains(searchStr) ||
                                l.Partidos.ToString().Contains(searchStr) ||
                                l.TarjetasAmarillas.ToString().Contains(searchStr) ||
                                l.TarjetasRojas.ToString().Contains(searchStr)
                            select new
                            {
                                l.idArbitro,
                                l.Nombre,
                                l.Apellido1,
                                l.Apellido2,
                                l.Fecha_Nacimiento,
                                l.Partidos,
                                l.TarjetasAmarillas,
                                l.TarjetasRojas

                            };

                foreach (var i in query)
                {
                    Singles.sArbitros l = new Singles.sArbitros();
                    l.idArbitro = i.idArbitro;
                    l.Nombre = i.Nombre;
                    l.Apellido1 = i.Apellido1;
                    l.Apellido2 = i.Apellido2;
                    l.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    l.Partidos = i.Partidos ?? 0;
                    l.TarjetasAmarillas = i.TarjetasAmarillas ?? 0;
                    l.TarjetasRojas = i.TarjetasRojas ?? 0;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sArbitros>(); }
        }

    }
}

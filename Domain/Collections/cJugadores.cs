﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cJugadores
    {
        public List<Singles.sJugadores> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sJugadores> eList = new List<Singles.sJugadores>();

            try
            {
                var query = from e in db.Jugadores
                            select new
                            {
                                e.idJugador,
                                e.idEquipo,
                                e.Nombre,
                                e.Apellido1,
                                e.Apellido2,
                                e.Fecha_Nacimiento,
                                e.Altura,
                                e.Peso,                                
                            };
                foreach (var i in query)
                {
                    Singles.sJugadores e = new Singles.sJugadores();
                    e.idJugador = i.idJugador;
                    e.idEquipo = i.idEquipo;
                    e.Nombre = i.Nombre;
                    e.Apellido1 = i.Apellido1;
                    e.Apellido2 = i.Apellido2;
                    e.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sJugadores>(); }
        }

        public List<Singles.sJugadores> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sJugadores> lList = new List<Singles.sJugadores>();

            try
            {
                var query = from l in db.Jugadores
                            where (l.idJugador.ToString().Contains(searchStr) ||
                                l.idEquipo.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Apellido1.Contains(searchStr) ||
                                l.Apellido2.Contains(searchStr) ||
                                    l.Fecha_Nacimiento.ToString().Contains(searchStr))

                            select new
                            {
                                l.idJugador,
                                l.idEquipo,
                                l.Nombre,
                                l.Apellido1,
                                l.Apellido2,
                                l.Fecha_Nacimiento,

                            };

                foreach (var i in query)
                {
                    Singles.sJugadores l = new Singles.sJugadores();
                    l.idJugador = i.idJugador;
                    l.idEquipo = i.idEquipo;
                    l.Nombre = i.Nombre;
                    l.Apellido1 = i.Apellido1;
                    l.Apellido2 = i.Apellido2;
                    l.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sJugadores>(); }
        }

        public List<Singles.sJugadores> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sJugadores> lList = new List<Singles.sJugadores>();

            try
            {
                var query = from l in db.Jugadores
                            select new
                            {
                                l.idJugador,
                                l.idEquipo,
                                l.Nombre,
                                l.Apellido1,
                                l.Apellido2,
                                l.Fecha_Nacimiento
                            };

                foreach (var i in query)
                {
                    Singles.sJugadores l = new Singles.sJugadores();
                    l.idJugador = i.idJugador;
                    l.idEquipo = i.idEquipo;
                    l.Nombre = i.Nombre;
                    l.Apellido1 = i.Apellido1;
                    l.Apellido2 = i.Apellido2;
                    l.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sJugadores>(); }
        }

        public List<Singles.sJugadores> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sJugadores> lList = new List<Singles.sJugadores>();

            try
            {
                var query = from l in db.Jugadores
                            where (l.idJugador.ToString().Contains(searchStr) ||
                                l.idEquipo.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Apellido1.Contains(searchStr) ||
                                l.Apellido2.Contains(searchStr) ||
                                    l.Fecha_Nacimiento.ToString().Contains(searchStr))
                            select new
                            {
                                l.idJugador,
                                l.idEquipo,
                                l.Nombre,
                                l.Apellido1,
                                l.Apellido2,
                                l.Fecha_Nacimiento
                            };

                foreach (var i in query)
                {
                    Singles.sJugadores l = new Singles.sJugadores();
                    l.idJugador = i.idJugador;
                    l.idEquipo = i.idEquipo;
                    l.Nombre = i.Nombre;
                    l.Apellido1 = i.Apellido1;
                    l.Apellido2 = i.Apellido2;
                    l.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sJugadores>(); }
        }

        public IEnumerable<sJugadores> List(long idEquipo)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            var list = new List<sJugadores>();

            try
            {
                var query = from r in db.Jugadores
                            where r.idEquipo == idEquipo
                            select r;


                foreach (var i in query)
                {
                    var item = new sJugadores();

                    item.idJugador = i.idJugador;
                    item.idEquipo = i.idEquipo;
                    item.Nombre = i.Nombre;
                    item.Apellido1 = i.Apellido1;
                    item.Apellido2 = i.Apellido2;
                    item.Fecha_Nacimiento = i.Fecha_Nacimiento;
                    item.Peso = i.Peso;
                    item.Altura = i.Altura;

                    list.Add(item);
                }

            }
            catch (Exception ex)
            {
                list = new List<sJugadores>();
            }

            return list;
        }


    }
}

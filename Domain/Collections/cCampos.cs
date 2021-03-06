﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;
using Domain.Singles;

namespace Domain.Collections
{
    public class cCampos
    {
        public List<Singles.sCampos> showAllResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCampos> eList = new List<Singles.sCampos>();

            try
            {
                var query = from e in db.Campos
                            select new
                            {
                                e.idCampo,
                                e.idClub,
                                e.Nombre,
                                e.Direccion
                            };
                foreach (var i in query)
                {
                    Singles.sCampos e = new Singles.sCampos();
                    e.idCampo = i.idCampo;
                    e.idClub = i.idClub;
                    e.Nombre = i.Nombre;
                    e.Direccion = i.Direccion;
                    eList.Add(e);
                }
                return eList;
            }
            catch { return new List<Singles.sCampos>(); }
        }

        public List<Singles.sCampos> showAllResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCampos> lList = new List<Singles.sCampos>();

            try
            {
                var query = from l in db.Campos
                            where (l.idCampo.ToString().Contains(searchStr) ||
                                l.idClub.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Direccion.Contains(searchStr))
                            select new
                            {
                                l.idCampo,
                                l.idClub,
                                l.Nombre,
                                l.Direccion
                            };

                foreach (var i in query)
                {
                    Singles.sCampos l = new Singles.sCampos();
                    l.idCampo = i.idCampo;
                    l.idClub = i.idClub;
                    l.Nombre = i.Nombre;
                    l.Direccion = i.Direccion;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCampos>(); }
        }

        public List<Singles.sCampos> showResults()
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCampos> lList = new List<Singles.sCampos>();

            try
            {
                var query = from l in db.Campos
                            select new
                            {
                                l.idCampo,
                                l.idClub,
                                l.Nombre,
                                l.Direccion
                            };

                foreach (var i in query)
                {
                    Singles.sCampos l = new Singles.sCampos();
                    l.idCampo = i.idCampo;
                    l.idClub = i.idClub;
                    l.Nombre = i.Nombre;
                    l.Direccion = i.Direccion;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCampos>(); }
        }

        public List<Singles.sCampos> showResults(string searchStr)
        {
            ProyectoEntities1 db = new ProyectoEntities1();
            List<Singles.sCampos> lList = new List<Singles.sCampos>();

            try
            {
                var query = from l in db.Campos
                            where (l.idCampo.ToString().Contains(searchStr) ||
                                l.idClub.ToString().Contains(searchStr) ||
                                l.Nombre.Contains(searchStr) ||
                                l.Direccion.Contains(searchStr))
                            select new
                            {
                                l.idCampo,
                                l.idClub,
                                l.Nombre,
                                l.Direccion
                            };

                foreach (var i in query)
                {
                    Singles.sCampos l = new Singles.sCampos();
                    l.idCampo = i.idCampo;
                    l.idClub = i.idClub;
                    l.Nombre = i.Nombre;
                    l.Direccion = i.Direccion;

                    lList.Add(l);
                }

                return lList;
            }
            catch { return new List<Singles.sCampos>(); }
        }

    }
}

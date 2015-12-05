using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gSanciones_Equipo
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Sanciones_Equipo _Sanciones_Equipo;
        bool _exist = false;

         public int idSancion_Equipo { get { return _Sanciones_Equipo.idSancion_Equipo; } }
        public string descripcion { get { return _Sanciones_Equipo.descripcion; } set { _Sanciones_Equipo.descripcion = value; } }
        public decimal multa { get { return _Sanciones_Equipo.multa; } set { _Sanciones_Equipo.multa = value; } }
        public int? idCategoria_Sancion { get { return _Sanciones_Equipo.idCategoria_Sancion; } set { _Sanciones_Equipo.idCategoria_Sancion = value; } }
        public int idEquipo { get { return _Sanciones_Equipo.idEquipo; } set { _Sanciones_Equipo.idEquipo = value; } }
        public bool exist { get { return _exist; } }

        private void nuevaSancion_Equipo()
        {
            _Sanciones_Equipo = new Sanciones_Equipo();
            _exist = false;
        }

        public gSanciones_Equipo()
        {
            nuevaSancion_Equipo();
        }
        public gSanciones_Equipo(int id)
        {
            try { _Sanciones_Equipo = _db.Sanciones_Equipo.Find(id); }
            catch { _Sanciones_Equipo = null; }

            if (_Sanciones_Equipo == null) { nuevaSancion_Equipo(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_Sanciones_Equipo.descripcion)) _Sanciones_Equipo.descripcion = "";

                if (_exist == false) { _db.Sanciones_Equipo.Add(_Sanciones_Equipo); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idSancion_Equipo)
        {
            try
            {
                var query = (from d in _db.Sanciones_Equipo where d.idSancion_Equipo == idSancion_Equipo select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Sanciones_Equipo.Remove(query);
                    _db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}

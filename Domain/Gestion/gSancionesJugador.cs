using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gSancionesJugador
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        SancionesJugador _SancionesJugador;
        bool _exist = false;
        
        public int idSancionJugador { get { return _SancionesJugador.idSancionJugador; } }
        public int idJugador { get { return _SancionesJugador.idJugador; } set { _SancionesJugador.idJugador = value; } }
        public string Descripcion { get { return _SancionesJugador.Descripcion; } set { _SancionesJugador.Descripcion = value; } }
        public decimal multa { get { return _SancionesJugador.multa; } set { _SancionesJugador.multa = value; } }
        public int? idCategoria_Sancion { get { return _SancionesJugador.idCategoria_Sancion; } set { _SancionesJugador.idCategoria_Sancion = value; } }
        public int? idArbitro { get { return _SancionesJugador.idArbitro; } set { _SancionesJugador.idArbitro = value; } }
        public bool exist { get { return _exist; } }

        private void nuevaSancionJugador()
        {
            _SancionesJugador = new SancionesJugador();
            _exist = false;
        }

        public gSancionesJugador()
        {
            nuevaSancionJugador();
        }
        public gSancionesJugador(int id)
        {
            try { _SancionesJugador = _db.SancionesJugador.Find(id); }
            catch { _SancionesJugador = null; }

            if (_SancionesJugador == null) { nuevaSancionJugador(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_SancionesJugador.Descripcion)) _SancionesJugador.Descripcion = "";

                if (_exist == false) { _db.SancionesJugador.Add(_SancionesJugador); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }
        public bool Quitar(int idSancionJugador)
        {
            try
            {
                var query = (from d in _db.SancionesJugador where d.idSancionJugador == idSancionJugador select d).SingleOrDefault();
                if (query != null)
                {
                    _db.SancionesJugador.Remove(query);
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

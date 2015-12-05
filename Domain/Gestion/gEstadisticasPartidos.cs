using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gEstadisticasPartidos
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        EstadisticasPartidos _estadisticasPartidos;
        bool _exist = false;

        public int idEstadistica_Partido { get { return _estadisticasPartidos.idEstadistica_Partido; } }
        public int idPartido { get { return _estadisticasPartidos.idPartido; } set { _estadisticasPartidos.idPartido = value; } }
        public int idEquipo { get { return _estadisticasPartidos.idEquipo; } set { _estadisticasPartidos.idEquipo = value; } }
        public int? Ensayos { get { return _estadisticasPartidos.Ensayos; } set { _estadisticasPartidos.Ensayos = value; } }
        public int? Conversiones { get { return _estadisticasPartidos.Conversiones; } set { _estadisticasPartidos.Conversiones = value; } }
        public int? GolpesCastigo { get { return _estadisticasPartidos.GolpesCastigo; } set { _estadisticasPartidos.GolpesCastigo = value; } }
        public int? Drops { get { return _estadisticasPartidos.Drops; } set { _estadisticasPartidos.Drops = value; } }
        public int? TarjetasAmarillas { get { return _estadisticasPartidos.TarjetasAmarillas; } set { _estadisticasPartidos.TarjetasAmarillas = value; } }
        public int? TarjetasRojas { get { return _estadisticasPartidos.TarjetasRojas; } set { _estadisticasPartidos.TarjetasRojas = value; } }
        public bool exist { get { return _exist; } }

        private void nuevaEstadisticaPartido()
        {
            _estadisticasPartidos = new EstadisticasPartidos();
            _exist = false;
        }

        public gEstadisticasPartidos()
        {
            nuevaEstadisticaPartido();
        }
        public gEstadisticasPartidos(int id)
        {
            try { _estadisticasPartidos = _db.EstadisticasPartidos.Find(id); }
            catch { _estadisticasPartidos = null; }

            if (_estadisticasPartidos == null) { nuevaEstadisticaPartido(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {

                if (_exist == false) { _db.EstadisticasPartidos.Add(_estadisticasPartidos); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idEstadistica_Partido)
        {
            try
            {
                var query = (from d in _db.EstadisticasPartidos where d.idEstadistica_Partido == idEstadistica_Partido select d).SingleOrDefault();
                if (query != null)
                {
                    _db.EstadisticasPartidos.Remove(query);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gPartidos
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Partidos _partidos;
        bool _exist = false;

        public int idPartido { get { return _partidos.idPartido; } }
        public int? idLiga { get { return _partidos.idLiga; } set { _partidos.idLiga = value; } }
        public int idEquipoLocal { get { return _partidos.idEquipoLocal; } set { _partidos.idEquipoLocal = value; } }
        public int idEquipoVisitante { get { return _partidos.idEquipoVisitante; } set { _partidos.idEquipoVisitante = value; } }
        public DateTime? Date { get { return _partidos.Date; } set { _partidos.Date = value; } }
        public int? idCampo { get { return _partidos.idCampo; } set { _partidos.idCampo = value; } }
        public int? idLive { get { return _partidos.idLive; } set { _partidos.idLive = value; } }
        public int? idArbitro { get { return _partidos.idArbitro; } set { _partidos.idArbitro = value; } }
        public bool isJugado { get { return _partidos.isJugado; } set { _partidos.isJugado = value; } }
        public bool exist { get { return _exist; } }

        private void nuevoPartido()
        {
            _partidos = new Partidos();
            _exist = false;
            isJugado = false;
        }

        public gPartidos()
        {
            nuevoPartido();
        }
        public gPartidos(int id)
        {
            try { _partidos = _db.Partidos.Find(id); }
            catch { _partidos = null; }

            if (_partidos == null) { nuevoPartido(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {

                if (_exist == false) { _db.Partidos.Add(_partidos); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idPartido)
        {
            try
            {
                var query = (from d in _db.Partidos where d.idPartido == idPartido select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Partidos.Remove(query);
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

        public int getIdLocal(int idPartido)
        {
            try
            {
                var query = (from d in _db.Partidos where d.idPartido == idPartido select d.idEquipoLocal).SingleOrDefault();
                if (query != null)
                {
                    return query;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int getIdVisitante(int idPartido)
        {
            try
            {
                var query = (from d in _db.Partidos where d.idPartido == idPartido select d.idEquipoVisitante).SingleOrDefault();
                if (query != null)
                {
                    return query;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int? getIdArbitro()
        {
            try
            {
                var query = (from d in _db.Partidos where d.idPartido == idPartido select d.idArbitro).SingleOrDefault();
                if (query != null)
                {
                    return query;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IQueryable<int> getEstadisticasPartido()
        {
            try
            {
                var query = (from d in _db.EstadisticasPartidos where d.idPartido == _partidos.idPartido select d.idEstadistica_Partido);

                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IQueryable<int> getEstadisticasPartidoLocal()
        {
            try
            {
                var query = (from d in _db.EstadisticasPartidos where d.idPartido == _partidos.idPartido select d.idEstadistica_Partido);

                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IQueryable<int> getEstadisticasPartidoVisitante()
        {
            try
            {
                var query = (from d in _db.EstadisticasPartidos where d.idPartido == _partidos.idPartido select d.idEstadistica_Partido);

                return query;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        
    }
}

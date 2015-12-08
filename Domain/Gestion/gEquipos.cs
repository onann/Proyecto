using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gEquipos
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Equipos _equipos;
        bool _exist = false;

        public int idEquipo { get { return _equipos.idEquipo; } }
        public int idClub { get { return _equipos.idClub; } set { _equipos.idClub = value; } }
        public string Nombre { get { return _equipos.Nombre; } set { _equipos.Nombre = value; } }
        public int? idLiga { get { return _equipos.idLiga; } set { _equipos.idLiga = value; } }
        public int Puntos { get { return _equipos.Puntos; } set { _equipos.Puntos = value; } }
        public int? Partidos_Jugados { get { return _equipos.Partidos_Jugados; } set { _equipos.Partidos_Jugados = value; } }
        public int? Partidos_Ganados { get { return _equipos.Partidos_Ganados; } set { _equipos.Partidos_Ganados = value; } }
        public int? Partidos_Perdidos { get { return _equipos.Partidos_Perdidos; } set { _equipos.Partidos_Perdidos = value; } }
        public int? Partidos_Empatados { get { return _equipos.Partidos_Empatados; } set { _equipos.Partidos_Empatados = value; } }
        public int? Puntos_Encajados { get { return _equipos.Puntos_Encajados; } set { _equipos.Puntos_Encajados = value; } }
        public int? Puntos_Anotados { get { return _equipos.Puntos_Anotados; } set { _equipos.Puntos_Anotados = value; } }
        public bool exist { get { return _exist; } }

        private void nuevoEquipo()
        {
            _equipos = new Equipos();
            _exist = false;
        }

        public gEquipos()
        {
            nuevoEquipo();
        }
        public gEquipos(int id)
        {
            try { _equipos = _db.Equipos.Find(id); }
            catch { _equipos = null; }

            if (_equipos == null) { nuevoEquipo(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_equipos.Nombre)) _equipos.Nombre = "";

                if (_exist == false) { _db.Equipos.Add(_equipos); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idEquipo)
        {
            try
            {
                var query = (from d in _db.Equipos where d.idEquipo == idEquipo select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Equipos.Remove(query);
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
        
        public void guardarEstadisticas(int idPartido)
        {
            _equipos.Partidos_Jugados = (from d in _db.Partidos     //introducir control de la variable isJugado para sumar solo los partidos que ya tienen resultado. Sería un metodo a ejecutar antes
                                         where d.idEquipoLocal == idEquipo || d.idEquipoVisitante == idEquipo
                                         select d).Count();
            var queryIdsPartidosJugados = (from d in _db.Partidos
                                         where d.idEquipoLocal == idEquipo || d.idEquipoVisitante == idEquipo
                                         select d.idPartido);
            
                int marcadorMiEquipo = (from d in _db.EstadisticasPartidos
                             where d.idPartido == idPartido
                                        where d.idEquipo == _equipos.idEquipo
                             select d.Marcador).FirstOrDefault();
                int marcadorContrario = (from d in _db.EstadisticasPartidos
                                        where d.idPartido == idPartido
                                         where d.idEquipo != _equipos.idEquipo
                                        select d.Marcador).FirstOrDefault();
                if (marcadorMiEquipo > marcadorContrario)
                {
                    _equipos.Partidos_Ganados += 1;
                    _equipos.Puntos += 4;
                }
                else
                {
                    if (marcadorMiEquipo < marcadorContrario)
                    {
                        _equipos.Partidos_Perdidos += 1;
                    }
                    else
                    {
                        _equipos.Partidos_Empatados += 1;
                        _equipos.Puntos += 2;
                    }

                }
                _equipos.Puntos_Encajados += marcadorContrario;
                _equipos.Puntos_Anotados += marcadorMiEquipo;

                if (((marcadorContrario - marcadorMiEquipo) <= 7) && ((marcadorContrario - marcadorMiEquipo) > 0))
                {
                    _equipos.Puntos += 1;
                }
                int? numeroEnsayos = (from d in _db.EstadisticasPartidos
                                     where d.idPartido == idPartido
                                      where d.idEquipo == _equipos.idEquipo
                                     select d.Ensayos).Sum();

                if (numeroEnsayos >= 4)
                {
                    _equipos.Puntos += 1;
                }

            
            save();
        }

        public String getNombreLiga()
        {
            var query = (from d in _db.Ligas
                        where d.idLiga == _equipos.idLiga
                        select d.nombre).FirstOrDefault();
            return query;
        }
    }
}

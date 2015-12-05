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
    }
}

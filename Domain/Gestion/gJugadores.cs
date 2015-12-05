using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gJugadores
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Jugadores _jugadores;
        bool _exist = false;

        public int idJugador { get { return _jugadores.idJugador; } }
        public int? idEquipo { get { return _jugadores.idEquipo; } set { _jugadores.idEquipo = value; } }
        public string Nombre { get { return _jugadores.Nombre; } set { _jugadores.Nombre = value; } }
        public string Apellido1 { get { return _jugadores.Apellido1; } set { _jugadores.Apellido1 = value; } }
        public string Apellido2 { get { return _jugadores.Apellido2; } set { _jugadores.Apellido2 = value; } }
        public DateTime? Fecha_Nacimiento { get { return _jugadores.Fecha_Nacimiento; } set { _jugadores.Fecha_Nacimiento = value; } }
        public int? Altura{ get { return _jugadores.Altura; } set { _jugadores.Altura = value; } }
        public int? Peso { get { return _jugadores.Peso; } set { _jugadores.Peso = value; } }
        public int? Puntos { get { return _jugadores.Puntos; } set { _jugadores.Puntos = value; } }
        public int? Partidos_Jugados { get { return _jugadores.Partidos_Jugados; } set { _jugadores.Partidos_Jugados = value; } }
        public int? Partidos_Ganados { get { return _jugadores.Partidos_Ganados; } set { _jugadores.Partidos_Ganados = value; } }
        public int? Partidos_Perdidos { get { return _jugadores.Partidos_Perdidos; } set { _jugadores.Partidos_Perdidos = value; } }
        public int? Partidos_Empatados { get { return _jugadores.Partidos_Empatados; } set { _jugadores.Partidos_Empatados = value; } }
        public int? TarjetasAmarillas { get { return _jugadores.TarjetasAmarillas; } set { _jugadores.TarjetasAmarillas = value; } }
        public int? TarjetasRojas { get { return _jugadores.TarjetasRojas; } set { _jugadores.TarjetasRojas = value; } }
        public bool exist { get { return _exist; } }

        private void nuevoJugador()
        {
            _jugadores = new Jugadores();
            _exist = false;
        }

        public gJugadores()
        {
            nuevoJugador();
        }
        public gJugadores(int id)
        {
            try { _jugadores = _db.Jugadores.Find(id); }
            catch { _jugadores = null; }

            if (_jugadores == null) { nuevoJugador(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_jugadores.Nombre)) _jugadores.Nombre = "";
                if (string.IsNullOrEmpty(_jugadores.Apellido1)) _jugadores.Apellido1 = "";
                if (string.IsNullOrEmpty(_jugadores.Apellido2)) _jugadores.Apellido2 = "";

                if (_exist == false) { _db.Jugadores.Add(_jugadores); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idJugador)
        {
            try
            {
                var query = (from d in _db.Jugadores where d.idJugador == idJugador select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Jugadores.Remove(query);
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

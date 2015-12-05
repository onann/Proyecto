using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
     public class gClubes
    {
         ProyectoEntities1 _db = new ProyectoEntities1();
        Clubes  _clubes;
        bool _exist = false;

        public int idClub { get { return _clubes.idClub; } }
        public string Nombre { get { return _clubes.Nombre; } set { _clubes.Nombre = value; } }
        public string Localidad { get { return _clubes.Localidad; } set { _clubes.Localidad = value; } }
        public string Telefono { get { return _clubes.Telefono; } set { _clubes.Telefono = value; } }
        public bool exist { get { return _exist; } }

        private void nuevoClub()
        {
            _clubes = new Clubes();
            _exist = false;
        }

        public gClubes()
        {
            nuevoClub();
        }
        public gClubes(int id)
        {
            try { _clubes = _db.Clubes.Find(id); }
            catch { _clubes = null; }

            if (_clubes == null) { nuevoClub(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_clubes.Nombre)) _clubes.Nombre = "";
                if (string.IsNullOrEmpty(_clubes.Localidad)) _clubes.Localidad = "";
                if (string.IsNullOrEmpty(_clubes.Telefono)) _clubes.Telefono = "";

                if (_exist == false) { _db.Clubes.Add(_clubes); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idClub)
        {
            try
            {
                var query = (from d in _db.Clubes where d.idClub == idClub select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Clubes.Remove(query);
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

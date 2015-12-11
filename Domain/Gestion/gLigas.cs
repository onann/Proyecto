using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gLigas
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Ligas _ligas;
        bool _exist = false;

         public int idLiga { get { return _ligas.idLiga; } }
        public string nombre { get { return _ligas.nombre; } set { _ligas.nombre = value; } }
        public int? idCategoriaLiga { get { return _ligas.idCategoriaLiga; } set { _ligas.idCategoriaLiga = value; } }
        public bool exist { get { return _exist; } }


        private void nuevaLiga()
        {
            _ligas = new Ligas();
            _exist = false;
        }

        public gLigas()
        {
            nuevaLiga();
        }
        public gLigas(int id)
        {
            try { _ligas = _db.Ligas.Find(id); }
            catch { _ligas = null; }

            if (_ligas == null) { nuevaLiga(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_ligas.nombre)) _ligas.nombre = "";

                if (_exist == false) { _db.Ligas.Add(_ligas); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idLiga)
        {
            try
            {
                var query = (from d in _db.Ligas where d.idLiga == idLiga select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Ligas.Remove(query);
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

        public String getNombreCategoria()
        {
            var query = (from d in _db.Categoria_Ligas
                         where d.idCategoriaLiga == _ligas.idCategoriaLiga
                         select d.NombreCategoria).FirstOrDefault();
            return query;
        }
    }
}

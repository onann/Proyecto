using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gCategoria_Ligas
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Categoria_Ligas _categoria_ligas;
        bool _exist = false;

        public int idCategoriaLiga { get { return _categoria_ligas.idCategoriaLiga; } }
        public string NombreCategoria { get { return _categoria_ligas.NombreCategoria; } set { _categoria_ligas.NombreCategoria = value; } }
        public bool exist { get { return _exist; } }

        private void nuevaCategoria_Liga()
        {
            _categoria_ligas = new Categoria_Ligas();
            _exist = false;
        }

        public gCategoria_Ligas()
        {
            nuevaCategoria_Liga();
        }
        public gCategoria_Ligas(int id)
        {
            try { _categoria_ligas = _db.Categoria_Ligas.Find(id); }
            catch { _categoria_ligas = null; }

            if (_categoria_ligas == null) { nuevaCategoria_Liga(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_categoria_ligas.NombreCategoria)) _categoria_ligas.NombreCategoria = "";

                if (_exist == false) { _db.Categoria_Ligas.Add(_categoria_ligas); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idCategoriaLigas)
        {
            try
            {
                var query = (from d in _db.Categoria_Ligas where d.idCategoriaLiga == idCategoriaLigas select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Categoria_Ligas.Remove(query);
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

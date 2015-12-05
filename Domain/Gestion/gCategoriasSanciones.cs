using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gCategoriasSanciones
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        CategoriasSanciones _categoriaSanciones;
        bool _exist = false;

         public int idCategoriaSancion { get { return _categoriaSanciones.idCategoriaSancion; } }
        public string Nombre  { get { return _categoriaSanciones.Nombre; } set { _categoriaSanciones.Nombre = value; } }
        public string Descripcion  { get { return _categoriaSanciones.Descripcion; } set { _categoriaSanciones.Descripcion = value; } }
        public bool exist { get { return _exist; } }

        private void nuevaCategoriaSanciones()
        {
            _categoriaSanciones = new CategoriasSanciones();
            _exist = false;
        }

        public gCategoriasSanciones()
        {
            nuevaCategoriaSanciones();
        }
        public gCategoriasSanciones(int id)
        {
            try { _categoriaSanciones = _db.CategoriasSanciones.Find(id); }
            catch { _categoriaSanciones = null; }

            if (_categoriaSanciones == null) { nuevaCategoriaSanciones(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_categoriaSanciones.Nombre)) _categoriaSanciones.Nombre = "";
                if (string.IsNullOrEmpty(_categoriaSanciones.Descripcion)) _categoriaSanciones.Descripcion = "";

                if (_exist == false) { _db.CategoriasSanciones.Add(_categoriaSanciones); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idCategoriaSancion)
        {
            try
            {
                var query = (from d in _db.CategoriasSanciones where d.idCategoriaSancion == idCategoriaSancion select d).SingleOrDefault();
                if (query != null)
                {
                    _db.CategoriasSanciones.Remove(query);
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

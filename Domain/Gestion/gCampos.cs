using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gCampos
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Campos _campos;
        bool _exist = false;

        public int idCampo { get { return _campos.idCampo; } }
        public string nombre { get { return _campos.Nombre; } set { _campos.Nombre = value; } }
        public int idEquipo { get { return _campos.idEquipo; } set { _campos.idEquipo = value; } }
        public string Direccion { get { return _campos.Direccion; } set { _campos.Direccion = value; } }
        public bool exist { get { return _exist; } }

        private void nuevoCampo()
        {
            _campos = new Campos();
            _exist = false;
        }

        public gCampos()
        {
            nuevoCampo();
        }
        public gCampos(int id)
        {
            try { _campos = _db.Campos.Find(id); }
            catch { _campos = null; }

            if (_campos == null) { nuevoCampo(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_campos.Nombre)) _campos.Nombre = "";
                if (string.IsNullOrEmpty(_campos.Direccion)) _campos.Direccion = "";

                if (_exist == false) { _db.Campos.Add(_campos);  }
                _db.SaveChanges();                
            }
            catch { todoOk = false; }
            return todoOk;
        }

        public bool Quitar(int idCampo)
        {
            try
            {
                var query = (from d in _db.Campos where d.idCampo == idCampo select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Campos.Remove(query);
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

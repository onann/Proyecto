using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gComentariosLive
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        ComentariosLive  _comentariosLive;
        bool _exist = false;

         public int idComentario { get { return _comentariosLive.idComentario; } }
        public int? idLive { get { return _comentariosLive.idLive; } set { _comentariosLive.idLive = value; } }
        public string texto { get { return _comentariosLive.texto; } set { _comentariosLive.texto = value; } }
        public int? minuto { get { return _comentariosLive.minuto; } set { _comentariosLive.minuto = value; } }
        public bool exist { get { return _exist; } }

        private void nuevoComentarioLive()
        {
            _comentariosLive = new ComentariosLive();
            _exist = false;
        }

        public gComentariosLive()
        {
            nuevoComentarioLive();
        }
        public gComentariosLive(int id)
        {
            try { _comentariosLive = _db.ComentariosLive.Find(id); }
            catch { _comentariosLive = null; }

            if (_comentariosLive == null) { nuevoComentarioLive(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_comentariosLive.texto)) _comentariosLive.texto = "";

                if (_exist == false) { _db.ComentariosLive.Add(_comentariosLive); }
                _db.SaveChanges();
            }
            catch { todoOk = false; }
            return todoOk;
        }
        public bool Quitar(int idComentario)
        {
            try
            {
                var query = (from d in _db.ComentariosLive where d.idComentario == idComentario select d).SingleOrDefault();
                if (query != null)
                {
                    _db.ComentariosLive.Remove(query);
                    _db.SaveChanges();
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                //logger.Error("Error al borrar la  Liga", ex);
                return false;
            }

        }
    }
}

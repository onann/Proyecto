using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gLive
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Live _live;
        bool _exist = false;

        public int idLive { get { return _live.idLive; } }
        public int? TiempoTranscurrido { get { return _live.TiempoTranscurrido; } set { _live.TiempoTranscurrido = value; } }
        public bool exist { get { return _exist; } }

        private void nuevoLive()
        {
            _live = new Live();
            _exist = false;
        }

        public gLive()
        {
            nuevoLive();
        }
        public gLive(int id)
        {
            try { _live = _db.Live.Find(id); }
            catch { _live = null; }

            if (_live == null) { nuevoLive(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {

                if (_exist == false) { _db.Live.Add(_live); }
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

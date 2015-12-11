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
        public int? idLocal { get { return _live.idLocal; } set { _live.idLocal = value; } }
        public int? idVisitante { get { return _live.idVisitante; } set { _live.idVisitante = value; } }
        public int? marcadorLocal { get { return _live.marcadorLocal; } set { _live.marcadorLocal = value; } }
        public int? marcadorVisitante { get { return _live.marcadorVisitante; } set { _live.marcadorVisitante = value; } }
        public DateTime? Date { get { return _live.Date; } set { _live.Date = value; } }
        public int? idCampo { get { return _live.idCampo; } set { _live.idCampo = value; } }
        public int? idArbitro { get { return _live.idArbitro; } set { _live.idArbitro = value; } }

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
                var query = (from d in _db.Live where d.idLive == idLive select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Live.Remove(query);
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

        public int getIdPartido()
        {
            return (from d in _db.Partidos where d.idLive == idLive select d.idPartido).SingleOrDefault();
        }
    }
}

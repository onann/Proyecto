using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositorio;

namespace Domain.Gestion
{
    public class gArbitros
    {
        ProyectoEntities1 _db = new ProyectoEntities1();
        Arbitros _arbitros; 
        bool _exist = false;  

        public int idArbitro { get { return _arbitros.idArbitro; }}
        public string Nombre { get { return _arbitros.Nombre;} set { _arbitros.Nombre = value;  }}
        public string Apellido1 { get { return _arbitros.Apellido1;} set { _arbitros.Apellido1 = value;  }}
        public string Apellido2{ get { return _arbitros.Apellido2;} set { _arbitros.Apellido2 = value;  }}
        public DateTime? Fecha_Nacimiento { get { return _arbitros.Fecha_Nacimiento;} set { _arbitros.Fecha_Nacimiento = value;  }}
        public int? Partidos { get { return _arbitros.Partidos;} set { _arbitros.Partidos = value;  }}
        public int? TarjetasAmarillas { get { return _arbitros.TarjetasAmarillas;} set { _arbitros.TarjetasAmarillas= value;  }}
        public int? TarjetasRojas { get { return _arbitros.TarjetasRojas;} set { _arbitros.TarjetasRojas = value;  }}
        public bool exist { get { return _exist; } }

        private void nuevoArbitro()
        {
            _arbitros = new Arbitros();
            _exist = false;
        }

        public gArbitros()
        {
            nuevoArbitro();
        }
        public gArbitros(int id)
        {
            try { _arbitros = _db.Arbitros.Find(id); }
            catch { _arbitros = null; }

            if (_arbitros == null) { nuevoArbitro(); }
            else { _exist = true; }
        }

        public bool save()
        {
            bool todoOk = true;
            try
            {
                if (string.IsNullOrEmpty(_arbitros.Nombre)) _arbitros.Nombre = "";
                if (string.IsNullOrEmpty(_arbitros.Apellido1)) _arbitros.Apellido1 = "";
                if (string.IsNullOrEmpty(_arbitros.Apellido2)) _arbitros.Apellido2 = "";

                if (_exist == false) { _db.Arbitros.Add(_arbitros);  }
                _db.SaveChanges();                
            }
            catch { todoOk = false; }
            return todoOk;
        }
        public bool Quitar(int idArbitro)
        {
            try
            {
                var query = (from d in _db.Arbitros where d.idArbitro == idArbitro select d).SingleOrDefault();
                if (query != null)
                {
                    _db.Arbitros.Remove(query);
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


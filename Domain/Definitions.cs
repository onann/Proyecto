using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public class Definitions
    {
        public enum eCoreStatus { Enabled = 0, Disabled = 1, Deleted = 2 }
        public enum eRolesUsers { Administrador = 0, Supervisor = 1, Operador = 2 }

        //public DateTime cDateDefaultValue = DateTime.Parse("01/01/1900");

        public class cJsonResultData
        {
            public bool success { get; set; }
            public bool reload { get; set; }
            public string redirect { get; set; }
            public string messaje { get; set; }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class RegistroContra
    {
        public int id { get; set; }

        public int? OperativoId { get; set; }
        public Operativos Operativo { get; set; }

        public int? AdministradorId { get; set; }
        public Administrador Administrador { get; set; }

        public string ContraPasada { get; set; }
       
    }
}

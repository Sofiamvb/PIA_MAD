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

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public string ContraPasada { get; set; }

       
    }
}

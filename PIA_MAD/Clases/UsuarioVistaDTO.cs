using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Clases
{
    public class UsuarioVistaDTO
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string AP { get; set; }
        public string AM { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string RFC { get; set; }
        public DateTime fechaNa { get; set; }
    }
}

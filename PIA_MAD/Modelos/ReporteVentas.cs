using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class ReporteVentas
    {
        public int id { get; set; }
        public DateTime FechaGen { get; set; }

        public List<Reservacion> reservaciones { get; set; }

        public int PagosT { get; set; }
    }
}

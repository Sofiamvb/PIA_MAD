using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Clases
{
    public class ReporteVentasDTO
    {
        public string Tipo { get; set; }
        public string NombreHotel { get; set; }
        public string Ciudad { get; set; }
        public int Anio { get; set; }
        public string Mes { get; set; }
        public decimal Monto { get; set; }
        public decimal Anticipo { get; set; }
        public decimal CantidadDescuento { get; set; }
        public decimal ServiciosAdicionales { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class ServicioAdicionalHotel
    {
        public int id { get; set; }
        public int HotelId { get; set; }
        public Hoteles Hotel { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}   

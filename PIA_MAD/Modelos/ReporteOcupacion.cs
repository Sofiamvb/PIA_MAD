using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class ReporteOcupacion
    {
        public int HotelId { get; set; }
        public string NombreHotel { get; set; }
        public string Ciudad { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
        public string TipoHabitacion { get; set; }
        public int NochesOcupadas { get; set; }
        public int Personas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class  Habitaciones
    {
        public int id { get; set; }

        public int HotelId { get; set; }

        public Hoteles Hotel { get; set; }

        public int CreadorAdministradorId { get; set; }
        public Administrador Creador { get; set; }

        public int? ModificadorAdministradorId { get; set; }
        public Administrador Modificador { get; set; } 

        public int NoCamas { get; set; }

        public string tipoCama { get; set; }

        public decimal PrecioNoche { get; set; }

        public int Capacidad { get; set; }

        public string nivelHab { get; set; }

        public string Vista { get; set; } 

        public string caracteristicas { get; set; }

        public string Amenidades { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime FechaModificacion { get; set; }

        public bool Disponible { get; set; }
    }
}

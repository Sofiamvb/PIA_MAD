using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class Reservacion
    {
        public int id { get; set; }

        public List<Usuario> cliente { get; set; }

        public List<Habitaciones> Habitacion { get; set; }

        public int CantPersonas { get; set; }

        public int Anticipo { get; set; }

        public DateTime Rangofech { get; set; }

        public List<Hoteles> Hotel { get; set; }

        public Guid CodigoReserva { get; set; } = Guid.NewGuid();

        public DateTime FechaEnt { get; set; }

        public DateTime FechaSal { get; set; }

        public DateTime FechaReserva { get; set; }
    }
}


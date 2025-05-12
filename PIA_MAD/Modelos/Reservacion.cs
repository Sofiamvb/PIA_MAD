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
        public int OperativoId { get; set; }
        
        public Operativos Operativo { get; set; }
        public int ClienteId { get; set; }
        public Usuario Cliente { get; set; }

        public Hoteles Hotel { get; set; }
        public int HotelId { get; set; }

        public int CantPersonas { get; set; }

        public decimal Anticipo { get; set; }

        public Guid CodigoReserva { get; set; } = Guid.NewGuid();

        public DateTime FechaEnt { get; set; }

        public DateTime FechaSal { get; set; }

        public DateTime FechaReserva { get; set; } = DateTime.Now;
        public DateTime? FechaCheckIn { get; set; }

        public bool CheckInRealizado { get; set; } = false;

        public bool CheckOUtRealizado { get; set; } = false;

        public List<HabitacionReservada> HabitacionReservada { get; set; }
    }
}


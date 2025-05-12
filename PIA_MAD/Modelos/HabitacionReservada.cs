using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class HabitacionReservada
    {
        public int Id { get; set; }

        public int HabitacionId { get; set; }
        public Habitaciones Habitacion { get; set; }

        public int ReservacionId { get; set; }
        public Reservacion Reservacion { get; set; }
        public int CantidadPersonas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class HabitacionCancelacion
    {
        public int Id { get; set; }

        public int HabitacionId { get; set; }
        public Habitaciones Habitacion { get; set; }

        public int CancelacionId { get; set; }
        public Cancelaciones Cancelacion { get; set; }

        public int CantidadPersonas { get; set; }
    }
}

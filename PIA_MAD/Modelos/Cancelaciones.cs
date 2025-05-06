using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class Cancelaciones
    {
        public int id { get; set; }

        public string TipoCancelacion { get; set; }

        public int ClienteId { get; set; }
        public Usuario Cliente { get; set; }

        public Hoteles Hotel { get; set; }
        public int HotelId { get; set; }

        public int AdministradorId { get; set; }

        public Administrador Administrador { get; set; }

        public int CantPersonas { get; set; }

        public decimal AnticipoADevolver { get; set; }

        public Guid CodigoReserva { get; set; } = Guid.NewGuid();

        public DateTime FechaEnt { get; set; }

        public DateTime FechaSal { get; set; }

        public DateTime FechaReserva { get; set; } = DateTime.Now;

        public DateTime FechaCancelacion { get; set; } = DateTime.Now;

        public bool CheckInRealizado { get; set; } = false;

        public List<HabitacionReservada> HabitacionesReservadas { get; set; }
    }
}

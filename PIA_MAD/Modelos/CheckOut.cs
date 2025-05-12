using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class CheckOut
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

        public decimal PorcentajeDescuento { get; set; }

        public decimal CantidadDescuento { get; set; }

        public decimal MontoTotal { get; set; }


        public Guid CodigoReserva { get; set; } 

        public DateTime FechaEntReserva { get; set; }

        public DateTime FechaSalReserva { get; set; }

        public DateTime FechaCheckIn { get; set; }

        public DateTime FechaSalReal { get; set; } = DateTime.Now;

        public DateTime FechaReserva { get; set; }

        public bool CheckInRealizado { get; set; } = true;

        public bool CheckOUtRealizado { get; set; } = true;
        public string SerieFactura { get; set; }
        public int FolioFactura { get; set; }
        public string RutaPdfFactura { get; set; }
        public List<CheckOutServicioAdicional> ServiciosAdicionales { get; set; }

        public List<HabitacionCheckout> HabitacionCheckout { get; set; }
    }
}

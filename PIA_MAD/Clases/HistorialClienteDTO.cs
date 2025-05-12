using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Clases
{
    public  class HistorialClienteDTO
    {
        public string Cliente { get; set; }
        public string CiudadHotel { get; set; }
        public string Hotel { get; set; }
        public string TipoHabitacion { get; set; }
        public int NumHabitacion { get; set; }
        public int CantidadPersonas { get; set; }
        public Guid CodigoReservacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaCheckIn { get; set; }
        public DateTime FechaCheckOut { get; set; }
        public string Status { get; set; }
        public decimal Anticipo { get; set; }
        public decimal MontoHospedaje { get; set; }
        public decimal MontoServicios { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal TotalFactura { get; set; }
    }
}

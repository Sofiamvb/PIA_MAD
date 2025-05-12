    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace PIA_MAD.Modelos
    {
        public class CheckOutServicioAdicional
        {
            public int Id { get; set; }

            public int CheckOutId { get; set; }
            public CheckOut CheckOut { get; set; }

            public int ServicioAdicionalHotelId { get; set; }
            public ServicioAdicionalHotel ServicioAdicionalHotel { get; set; }

            public int Cantidad { get; set; } // Por si el cliente usó más de una vez ese servicio
        }
    }

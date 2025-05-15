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

            public string Nombre { get; set; }
            public decimal Precio { get; set; }

        public int Cantidad { get; set; } // Por si el cliente usó más de una vez ese servicio
        }
    }

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class Hoteles
    {
        public int id { get; set; }
        public string Nombre { get; set; }

        public string pais { get; set; }

        public string estado { get; set; }

        public string ciudad { get; set; }

        public string domicilio { get; set; }

        public int Pisos { get; set; }

        public bool ZonaTur { get; set; }

        public string caracteristicas { get; set; }

        public string amennidades { get; set; }

        public int cantHab { get; set; }

        public string serviciosAd { get; set; }

        public bool FrentePlaya { get; set; }

        public int CantPiscina { get; set; }

        public bool SalonEv { get; set; }
    }
}

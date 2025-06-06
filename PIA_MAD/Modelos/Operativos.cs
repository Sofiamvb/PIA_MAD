﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class Operativos
    {
        public int id { get; set; }

        public int CreadorAdministradorId { get; set; }

        public Administrador Creador { get; set; } 

        public int? ModificadorAdministradorId { get; set; }

        public Administrador Modificador { get; set; } 

        public string Nombre { get; set; }

        public string AP { get; set; }

        public string AM { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public int Nomina { get; set; }

        public DateTime fechaNa { get; set; }

        public DateTime FechaRegistro { get; set; }
        
        public DateTime FechaModificacion { get; set; }

        public string Contra { get; set; }
    }
}

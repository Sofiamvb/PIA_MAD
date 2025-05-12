using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Modelos
{
    public class Hoteles
    {
        public int id { get; set; }
        public int CreadorAdministradorId { get; set; }
        public Administrador Creador { get; set; }
        public int? ModificadorAdministradorId { get; set; }
        public Administrador Modificador { get; set; }
        public string Nombre { get; set; }
        public string pais { get; set ; }
        public string estado { get; set; }
        public string ciudad { get; set; }
        public string domicilio { get; set; }
        public int Pisos { get; set; }
        public bool ZonaTur { get; set; }
        public string caracteristicas { get; set; }
        public string amenidades { get; set; }
        public int cantHab { get; set; }
        public bool FrentePlaya { get; set; }
        public int CantPiscina { get; set; }
        public bool SalonEv { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public List<ServicioAdicionalHotel> ServiciosAdicionales { get; set; }
    }
}

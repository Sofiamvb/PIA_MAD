using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Clases
{
    public class ConceptoFactura
    {
        public int Cantidad { get; set; }
        public string Unidad { get; set; }
        public string ClaveUnidadSAT { get; set; }
        public string ClaveProductoServicio { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Descuentos { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Importe { get; set; }
    }
}

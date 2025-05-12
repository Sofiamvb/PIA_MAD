using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD
{
    class GestorVentanas
    {

        public static Registro_de_clientes VentanaClientes;
        public static Reservaciones VentanaReservaciones;
        public static Check_In VentanaCheckIn;
        public static Check_Out VentanaCheckOut;
        public static ModificarCliente VentanaModificarCliente;
        


        public static void CerrarTodasMenos(Form actual)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f != actual)
                    f.Hide(); 
            }
        }

    }
}

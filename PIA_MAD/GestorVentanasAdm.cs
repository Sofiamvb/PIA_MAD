using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD
{
    class GestorVentanasAdm
    {
        
        public static Registro_de_hoteles VentanaHoteles;
        public static Registro_de_habitaciones VentanaHabitaciones;
        public static Cancelacion_de_reservación VentanaCancelarReserva;
        public static Reporte_de_ventas VentanaRepoVentas;
        public static Reporte_de_ocupación VentanaRepoOcupacion;
        public static Historial_del_cliente VentanaHistorialCliente;
        public static Mod_Hotel VentanaModHotel;
        public static Modificar_Habitaciones VentanaModHab;
        public static RegistroAdministradores VentanaRegEmpl;
        public static Cancelacion_de_reservación VentanaCancelacionReservacion;
        public static Informacion_Hotel VentanaInformacion_Hotel;
        public static Informacion_de_habitaciones VentanaInformacionHabitaciones;
        public static ModificarAdministradores VentanaModificarAdministradores;
        public static ModificarOperativos VentanaModificarOperativos;

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

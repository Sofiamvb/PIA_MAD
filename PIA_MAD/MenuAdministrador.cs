using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class MenuAdministrador : UserControl
    {
        public MenuAdministrador()
        {
            InitializeComponent();
        }

        private void cancelarReservaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaCancelarReserva == null || GestorVentanasAdm.VentanaCancelarReserva.IsDisposed)
                GestorVentanasAdm.VentanaCancelarReserva = new Cancelacion_de_reservación();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaCancelarReserva);
            GestorVentanasAdm.VentanaCancelarReserva.Show();
            GestorVentanasAdm.VentanaCancelarReserva.Focus();
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void registroDeHotelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaHoteles == null || GestorVentanasAdm.VentanaHoteles.IsDisposed)
                GestorVentanasAdm.VentanaHoteles = new Registro_de_hoteles();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaHoteles);
            GestorVentanasAdm.VentanaHoteles.Show();
            GestorVentanasAdm.VentanaHoteles.Focus();
        }

        private void modificarRegistroDeHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaModHotel == null || GestorVentanasAdm.VentanaModHotel.IsDisposed)
                GestorVentanasAdm.VentanaModHotel = new Mod_Hotel();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaModHotel);
            GestorVentanasAdm.VentanaModHotel.Show();
            GestorVentanasAdm.VentanaModHotel.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaHabitaciones == null || GestorVentanasAdm.VentanaHabitaciones.IsDisposed)
                GestorVentanasAdm.VentanaHabitaciones = new Registro_de_habitaciones();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaHabitaciones);
            GestorVentanasAdm.VentanaHabitaciones.Show();
            GestorVentanasAdm.VentanaHabitaciones.Focus();
        }

        private void modificarRegistroDeHabitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaModHab == null || GestorVentanasAdm.VentanaModHab.IsDisposed)
                GestorVentanasAdm.VentanaModHab = new Modificar_Habitaciones();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaModHab);
            GestorVentanasAdm.VentanaModHab.Show();
            GestorVentanasAdm.VentanaModHab.Focus();
        }

        private void reporteDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (GestorVentanasAdm.VentanaRepoVentas == null || GestorVentanasAdm.VentanaRepoVentas.IsDisposed)
                GestorVentanasAdm.VentanaRepoVentas = new Reporte_de_ventas();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaRepoVentas);
            GestorVentanasAdm.VentanaRepoVentas.Show();
            GestorVentanasAdm.VentanaRepoVentas.Focus();

        }

        private void reporteDeOcupaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaRepoOcupacion == null || GestorVentanasAdm.VentanaRepoOcupacion.IsDisposed)
                GestorVentanasAdm.VentanaRepoOcupacion = new Reporte_de_ocupación();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaRepoOcupacion);
            GestorVentanasAdm.VentanaRepoOcupacion.Show();
            GestorVentanasAdm.VentanaRepoOcupacion.Focus();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaHistorialCliente == null || GestorVentanasAdm.VentanaHistorialCliente.IsDisposed)
                GestorVentanasAdm.VentanaHistorialCliente = new Historial_del_cliente();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaHistorialCliente);
            GestorVentanasAdm.VentanaHistorialCliente.Show();
            GestorVentanasAdm.VentanaHistorialCliente.Focus();
        }

        private void registroEmpleadoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaRegEmpl == null || GestorVentanasAdm.VentanaRegEmpl.IsDisposed)
                GestorVentanasAdm.VentanaRegEmpl = new RegistroAdministradores();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaRegEmpl);
            GestorVentanasAdm.VentanaRegEmpl.Show();
            GestorVentanasAdm.VentanaRegEmpl.Focus();
        }

        private void cancelacionReservacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaCancelacionReservacion == null || GestorVentanasAdm.VentanaCancelacionReservacion.IsDisposed)
                GestorVentanasAdm.VentanaCancelacionReservacion = new Cancelacion_de_reservación();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaCancelacionReservacion);
            GestorVentanasAdm.VentanaCancelacionReservacion.Show();
            GestorVentanasAdm.VentanaCancelacionReservacion.Focus();
        }

        private void administrativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaModificarAdministradores == null || GestorVentanasAdm.VentanaModificarAdministradores.IsDisposed)
                GestorVentanasAdm.VentanaModificarAdministradores = new ModificarAdministradores();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaModificarAdministradores);
            GestorVentanasAdm.VentanaModificarAdministradores.Show();
            GestorVentanasAdm.VentanaModificarAdministradores.Focus();
        }

        private void operativosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaModificarOperativos == null || GestorVentanasAdm.VentanaModificarOperativos.IsDisposed)
                GestorVentanasAdm.VentanaModificarOperativos = new ModificarOperativos();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaModificarOperativos);
            GestorVentanasAdm.VentanaModificarOperativos.Show();
            GestorVentanasAdm.VentanaModificarOperativos.Focus();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanasAdm.VentanaRegresarIni == null || GestorVentanasAdm.VentanaRegresarIni.IsDisposed)
                GestorVentanasAdm.VentanaRegresarIni = new Form1();

            GestorVentanasAdm.CerrarTodasMenos(GestorVentanasAdm.VentanaRegresarIni);
            GestorVentanasAdm.VentanaRegresarIni.Show();
            GestorVentanasAdm.VentanaRegresarIni.Focus();
        }
    }
}

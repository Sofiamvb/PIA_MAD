using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIA_MAD
{
    public partial class MenuSuperior : UserControl
    {
        public MenuSuperior()
        {
            InitializeComponent();
        }

        private void registroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanas.VentanaClientes == null || GestorVentanas.VentanaClientes.IsDisposed)
                GestorVentanas.VentanaClientes = new Registro_de_clientes();

            GestorVentanas.CerrarTodasMenos(GestorVentanas.VentanaClientes);
            GestorVentanas.VentanaClientes.Show();
            GestorVentanas.VentanaClientes.Focus();
        }

        private void Menu_VReservacion_Click(object sender, EventArgs e)
        {
            if (GestorVentanas.VentanaReservaciones == null || GestorVentanas.VentanaReservaciones.IsDisposed)
                GestorVentanas.VentanaReservaciones = new Reservaciones();

            GestorVentanas.CerrarTodasMenos(GestorVentanas.VentanaReservaciones);
            GestorVentanas.VentanaReservaciones.Show();
            GestorVentanas.VentanaReservaciones.Focus();
        }

        private void Menu_VCheckIn_Click(object sender, EventArgs e)
        {
            if (GestorVentanas.VentanaCheckIn == null || GestorVentanas.VentanaCheckIn.IsDisposed)
                GestorVentanas.VentanaCheckIn = new Check_In();

            GestorVentanas.CerrarTodasMenos(GestorVentanas.VentanaCheckIn);
            GestorVentanas.VentanaCheckIn.Show();
            GestorVentanas.VentanaCheckIn.Focus();
        }

        private void Menu_VCheckOut_Click(object sender, EventArgs e)
        {
            if (GestorVentanas.VentanaCheckOut == null || GestorVentanas.VentanaCheckOut.IsDisposed)
                GestorVentanas.VentanaCheckOut = new Check_Out();

            GestorVentanas.CerrarTodasMenos(GestorVentanas.VentanaCheckOut);
            GestorVentanas.VentanaCheckOut.Show();
            GestorVentanas.VentanaCheckOut.Focus();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void modificarRegistroDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanas.VentanaModificarCliente == null || GestorVentanas.VentanaModificarCliente.IsDisposed)
                GestorVentanas.VentanaModificarCliente = new ModificarCliente();

            GestorVentanas.CerrarTodasMenos(GestorVentanas.VentanaModificarCliente);
            GestorVentanas.VentanaModificarCliente.Show();
            GestorVentanas.VentanaModificarCliente.Focus();
        }

        private void cerrarSesónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GestorVentanas.VentanaRegresoInicio == null || GestorVentanas.VentanaRegresoInicio.IsDisposed)
                GestorVentanas.VentanaRegresoInicio = new Form1();

            GestorVentanas.CerrarTodasMenos(GestorVentanas.VentanaRegresoInicio);
            GestorVentanas.VentanaRegresoInicio.Show();
            GestorVentanas.VentanaRegresoInicio.Focus();
        }
    }
}

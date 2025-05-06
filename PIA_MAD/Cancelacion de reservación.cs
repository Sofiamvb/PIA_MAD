using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PIA_MAD.Clases;

namespace PIA_MAD
{
    public partial class Cancelacion_de_reservación : Form
    {
        private Guid codigoreserva;
        public Cancelacion_de_reservación()
        {
            InitializeComponent();
            DTP_CancelarReservacion.ShowUpDown = true;
            DTP_CancelarReservacion.Enabled = false;
            BTN_CancelarReservacion.Enabled = false;
            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaHoteles = null;
        }
        private void TB_CodigoCancelacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                string checkin_code = TB_CodigoCancelacion.Text;
                using (var DB = new ApplicationDbContext())
                {
                    if (Guid.TryParse(checkin_code, out codigoreserva))
                    {
                        var validarcodigo = DB.Reservaciones
                            .Include(r => r.HabitacionReservada)
                            .ThenInclude(hr => hr.Habitacion)
                            .FirstOrDefault(r => r.CodigoReserva == codigoreserva);

                        if (validarcodigo != null)
                        {
                            BTN_CancelarReservacion.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Codigo no valido, intenta de nuevo.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El código ingresado no es válido.");
                    }
                }
            }
        }

        private void TB_CodigoCancelacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_CancelarReservacion_Click(object sender, EventArgs e)
        {
            using (var DB = new ApplicationDbContext()) 
            {
                var servicio = new ReservacionService(DB);
                bool reservacioncancelada = servicio.CancelarReservacionManual(codigoreserva);
                if (reservacioncancelada == true)
                {
                    MessageBox.Show("Se ha cancelado la reservacion.");
                }
            }
        }
    }
}

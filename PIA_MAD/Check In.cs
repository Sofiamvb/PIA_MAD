using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using PIA_MAD.Clases;

namespace PIA_MAD
{
    public partial class Check_In : Form
    {
        private string checkin_code;
        Empleado empleado = Empleado.ObtenerInstancia();
        public Check_In()
        {
            InitializeComponent();
            BTN_CheckIn.Enabled = false;
            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuSuperior());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanas.VentanaClientes = null;
        }

        private void Check_In_Load(object sender, EventArgs e)
        {

        }


        private void BTN_CheckIn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TB_CheckIn.Text))
            {
                checkin_code = TB_CheckIn.Text;
                using (var DB = new ApplicationDbContext())
                {
                    if (Guid.TryParse(checkin_code, out Guid codigoReservaGuid))
                    {
                        var validarcheckin = DB.Reservaciones
                            .Include(r => r.HabitacionReservada)
                            .ThenInclude(hr => hr.Habitacion)
                            .FirstOrDefault(r => r.CodigoReserva == codigoReservaGuid);

                        if (validarcheckin != null)
                        {
                            foreach (var habitacionReservada in validarcheckin.HabitacionReservada)
                            {                       
                                int habitacionId = habitacionReservada.HabitacionId;
                                int reservacionId = habitacionReservada.ReservacionId;
                                DB.Database.ExecuteSqlRaw("UPDATE dbo.Reservaciones SET CheckInRealizado = 1 WHERE id = {0}", reservacionId);
                            }
                            MessageBox.Show($"Check In realizado por: {empleado.GetNombreCompleto()} las habitaciones ya estan ocupadas.");
                            this.Hide();
                            var nuevoFormulario = new Check_In();
                            nuevoFormulario.Show();
                            this.Close();
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

        private void TB_CheckIn_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TB_CheckIn.Text)) {
                BTN_CheckIn.Enabled = true;
            }
        }
    }
}

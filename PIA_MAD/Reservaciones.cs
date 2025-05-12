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
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
using PIA_MAD.Clases;




namespace PIA_MAD
{
    public partial class Reservaciones : Form
    {
        bool isFormatting = false;
        private string ciudadbuscada;
        private string nivelHabSeleccionado;
        private DateTime FechaEnt;
        private DateTime FechaSal;
        private string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        private string patronContrasenia = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).+$";
        private decimal anticipofijo = 999.00m;
        private int clientid;
        private int hotelid;
        private int maxcapacidadhab;
        private int cantidadpersonas;
        private int cantPersonasHab;
        private decimal anticipo;
        Empleado empleado = Empleado.ObtenerInstancia();
        private List<Habitaciones> habitacionesdisponibles;
        private List<Habitaciones> habitacionesreservadas = new List<Habitaciones>();
        private List<Habitaciones> habitacionesEncontradas;
        private List<(Habitaciones habitacion, int cantidadPersonas)> habitacionesReservadasConPersonas = new List<(Habitaciones, int)>();


        public Reservaciones()
        {
            InitializeComponent();
            DTP_FechaEntrada.MinDate = DateTime.Today;
            DTP_FechaEntrada.Enabled = false;
            DTP_FechaSalida.Enabled = false;
            DTP_FechaReservacion.ShowUpDown = true;
            DTP_FechaReservacion.Enabled = false;
            LB_MostrarHabitaciones.Enabled = false;

            TB_BusquedaHoteles.Enabled = false;
            BTN_BusquedaHoteles.Enabled = false;

            BTN_Reservar.Enabled = false;
            BTN_EliminarHab.Enabled = false;
            BTN_AgregarHabitacion.Enabled = false;
            BTN_BuscarHabitaciones.Enabled = false;
            CB_SeleccionNivelHab.Enabled = false;
            BTN_BuscarHabitaciones.Enabled = false;
            TB_CantidadPersonas.Enabled = false;
            TB_Anticipo.Text = Utilidades.FormatearComoMoneda(1000.00m);
            TB_Anticipo.Enabled = false;

            LV_MostrarCliente.View = View.Details;
            LV_MostrarCliente.FullRowSelect = true;
            LV_MostrarCliente.GridLines = true;
            LV_MostrarCliente.Columns.Clear();
            LV_MostrarCliente.Columns.Add("Id", 160);
            LV_MostrarCliente.Columns.Add("Nombre", 160);
            LV_MostrarCliente.Columns.Add("Apellido paterno", 160);
            LV_MostrarCliente.Columns.Add("Apellido materno", 160);
            LV_MostrarCliente.Columns.Add("Celular", 160);

            string[] opNivelHab = { "Sin preferencia", "Estandar", "Deluxe", "Ejecutiva", "Suite" };
            CB_SeleccionNivelHab.Items.AddRange(opNivelHab);

            if (CB_SeleccionNivelHab.Items.Count > 0)
                CB_SeleccionNivelHab.SelectedIndex = 0;


            this.FormClosed += FormClosedHandler;
            MenuSuperior menu = new MenuSuperior();
            menu.Location = new Point((this.ClientSize.Width - menu.Width) / 2, 0);
            this.Controls.Add(menu);
        }

        private List<Habitaciones> GetHabitacionesDisponibles(int hotelseleccionadoid, DateTime fechasalidaseleccionada, DateTime fechaentradaseleccionada, string nivelHabSeleccionado)
        {
            if (LB_MostrarHoteles.SelectedValue != null)
            {
                using (var DB = new ApplicationDbContext())
                {
                    if (nivelHabSeleccionado != "Sin preferencia")
                    {
                        string query = @"SELECT * FROM Habitaciones h 
                    WHERE h.HotelId = {0}
                    AND h.nivelHab = {3}
                    AND h.id NOT IN (
                        SELECT hr.HabitacionId 
                        FROM HabitacionReservada hr 
                        INNER JOIN Reservaciones r ON hr.ReservacionId = r.id 
                        WHERE r.HotelId = {0}
                        AND r.FechaEnt < {1}
                        AND r.FechaSal > {2}
                    );";

                        var habdisponibles = DB.Habitaciones.FromSqlRaw(
                            query,
                            hotelseleccionadoid, fechasalidaseleccionada, fechaentradaseleccionada, nivelHabSeleccionado
                        ).ToList();

                        return habdisponibles;
                    }
                    else
                    {
                        string query = @"SELECT * FROM Habitaciones h 
                    WHERE h.HotelId = {0}
                    AND h.id NOT IN (
                        SELECT hr.HabitacionId 
                        FROM HabitacionReservada hr 
                        INNER JOIN Reservaciones r ON hr.ReservacionId = r.id 
                        WHERE r.HotelId = {0}
                        AND r.FechaEnt < {1}
                        AND r.FechaSal > {2}
                    );";

                        var habdisponibles = DB.Habitaciones.FromSqlRaw(
                            query,
                            hotelseleccionadoid, fechasalidaseleccionada, fechaentradaseleccionada
                        ).ToList();

                        return habdisponibles;
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un hotel primero.");
                return null;
            }
        }

        private decimal ObtenerAnticipoLimpio()
        {
            string texto = TB_Anticipo.Text.Replace("$", "").Replace(",", "").Trim();

            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultado))
            {
                return resultado;
            }
            else
            {
                throw new Exception("Anticipo inválido");
            }
        }

        private void ObtenerlistViewDatos()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var usuarios = context.Vista_UsuariosBasica
                        .Take(20) // Limita a 20 desde C#
                        .ToList();
                    LV_MostrarCliente.Items.Clear();
                    foreach (var u in usuarios)
                    {
                        var item = new ListViewItem(u.id.ToString());
                        item.SubItems.Add(u.Nombre);
                        item.SubItems.Add(u.AP);
                        item.SubItems.Add(u.AM);
                        item.SubItems.Add(u.Celular);
                        LV_MostrarCliente.Items.Add(item);
                    }
                }

            }
            catch (Exception ex) {
                MessageBox.Show($"Hubo un error: {ex.Message}");
            }
        }
        private void LimpiarFormulario(Control parent = null)
        {
            if (parent == null)
                parent = this;

            foreach (Control c in parent.Controls)
            {
                if (c is TextBox tb)
                    tb.Text = "";

                else if (c is ComboBox cb)
                    cb.SelectedIndex = cb.Items.Count > 0 ? 0 : -1;

                else if (c is DateTimePicker dtp)
                    dtp.Value = DateTime.Now;

                else if (c is CheckBox chk)
                    chk.Checked = false;

                else if (c is RadioButton rb)
                    rb.Checked = false;

                // 👇 Muy importante: recursión
                if (c.HasChildren)
                    LimpiarFormulario(c);
            }
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanas.VentanaClientes = null;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Reservaciones_Load(object sender, EventArgs e)
        {
            ObtenerlistViewDatos();
        }

        private void BTN_BusquedaClientes_Click(object sender, EventArgs e)
        {
            string correobuscado = TB_BusquedaCliente.Text;
            if (!Regex.IsMatch(correobuscado, patronCorreo))
            {
                MessageBox.Show("El correo ingresado debe tener un formato de correo");
                return;
            }
            using (var context = new ApplicationDbContext())
            {
                var cliente = context.Usuarios.FromSqlRaw("SELECT * FROM dbo.Usuarios WHERE Correo={0}", correobuscado).FirstOrDefault();

                LV_MostrarCliente.Items.Clear();

                if (cliente == null)
                {
                    MessageBox.Show($"No se encontro ningun cliente con el correo {correobuscado} intenta de nuevo con otro correo.");
                    this.Hide();
                    var nuevoFormulario = new Reservaciones();
                    nuevoFormulario.Show();
                    this.Close();
                    return;
                }
                else
                {
                    var item = new ListViewItem(cliente.id.ToString());
                    clientid = cliente.id;
                    item.SubItems.Add(cliente.Nombre);
                    item.SubItems.Add(cliente.AP);
                    item.SubItems.Add(cliente.AM);
                    item.SubItems.Add(cliente.Celular);
                    item.Tag = cliente;

                    LV_MostrarCliente.Items.Add(item);

                    TB_BusquedaHoteles.Enabled = true;
                    BTN_BusquedaHoteles.Enabled = true;

                }
            }
        }



        private void BTN_BusquedaHoteles_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TB_BusquedaHoteles.Text, patronNombre))
            {
                MessageBox.Show("La ciudad solo puede contener letras y espacios");
                return;
            }
            ciudadbuscada = TB_BusquedaHoteles.Text;
            using (var context = new ApplicationDbContext())
            {
                var Hoteles = context.Hoteles.FromSqlRaw("SELECT * FROM dbo.Hoteles WHERE ciudad={0}", ciudadbuscada).ToList();
                if (Hoteles.Count == 0)
                {
                    MessageBox.Show($"No hay hoteles en la ciudad de {ciudadbuscada} intenta con otra");
                    return;
                }
                else
                {
                    LB_MostrarHoteles.DataSource = Hoteles;
                    LB_MostrarHoteles.DisplayMember = "Nombre";
                    LB_MostrarHoteles.ValueMember = "id";
                    CB_SeleccionNivelHab.Enabled = true;
                }

            }
        }

        private void LB_MostrarHoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_MostrarHoteles.SelectedItem is Hoteles hotelSeleccionado)
            {
                RTB_MostrarAMHoteles.Clear();
                var amenidades = hotelSeleccionado.amenidades.Split(',');
                hotelid = hotelSeleccionado.id;
                foreach (var a in amenidades)
                {
                    RTB_MostrarAMHoteles.AppendText("• " + a.Trim() + Environment.NewLine);
                }
                LB_MostrarHabitaciones.DataSource = null;
                LB_MostrarHabitaciones.Items.Clear();
                RTB_MostrarAMHabitaciones.Clear();
                LB_HabSeleccionadas.DataSource = null;
                LB_HabSeleccionadas.Items.Clear();
                habitacionesreservadas.Clear();
            }
        }

        private void CB_SeleccionNivelHab_SelectedIndexChanged(object sender, EventArgs e)
        {
            nivelHabSeleccionado = CB_SeleccionNivelHab.SelectedItem.ToString();
            DTP_FechaEntrada.Enabled = true;
        }

        private void DTP_FechaEntrada_ValueChanged(object sender, EventArgs e)
        {
            DTP_FechaSalida.Enabled = true;
            DTP_FechaSalida.MinDate = DTP_FechaEntrada.Value.AddDays(1);
            FechaEnt = DTP_FechaEntrada.Value;
        }

        private void DTP_FechaSalida_ValueChanged(object sender, EventArgs e)
        {
            BTN_BuscarHabitaciones.Enabled = true;
            FechaSal = DTP_FechaSalida.Value;
        }

        private void BTN_BuscarHabitaciones_Click(object sender, EventArgs e)
        {
            habitacionesEncontradas = GetHabitacionesDisponibles(hotelid, FechaSal, FechaEnt, nivelHabSeleccionado);
            Debug.WriteLine(habitacionesEncontradas);
            LB_MostrarHabitaciones.Enabled = true;
            LB_MostrarHabitaciones.DataSource = habitacionesEncontradas;
            LB_MostrarHabitaciones.DisplayMember = "id";
            LB_MostrarHabitaciones.ValueMember = "id";

            habitacionesdisponibles = habitacionesEncontradas;

        }

        private void LB_MostrarHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LB_MostrarHabitaciones.SelectedItem is Habitaciones habitacionseleccionada)
            {
                RTB_MostrarAMHabitaciones.Clear();
                var amenidades = habitacionseleccionada.Amenidades.Split(',');

                foreach (var a in amenidades)
                {
                    RTB_MostrarAMHabitaciones.AppendText("• " + a.Trim() + Environment.NewLine);
                }
                maxcapacidadhab = habitacionseleccionada.Capacidad;
                LBL_MaxCapHab.Text = habitacionseleccionada.Capacidad.ToString();
                TB_CantidadPersonas.Enabled = true;
            }

        }

        private void TB_CantidadPersonas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string CantPerHab = TB_CantidadPersonas.Text;
                if (string.IsNullOrWhiteSpace(CantPerHab))
                {
                    CantPerHab = "0";
                }
                int cantper = Int32.Parse(CantPerHab);
                int result = maxcapacidadhab - cantper;
                if (result < 0)
                {
                    Debug.WriteLine($"Dentro del if. Resultado: {result}");
                    MessageBox.Show("Número no válido, tiene que ser menor o igual a la disponibilidad.");
                    TB_CantidadPersonas.Text = "0";
                    return;
                }
                cantPersonasHab = cantper;
                BTN_AgregarHabitacion.Enabled = true;
            }
            catch (FormatException error)
            {
                MessageBox.Show("Formato no válido, tiene que ser un número", error.Message);
                TB_CantidadPersonas.Text = "0";
                return;
            }
        }

        private void BTN_AgregarHabitacion_Click(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(LB_MostrarHabitaciones.SelectedValue);

            var habitacionAEliminar = habitacionesdisponibles.FirstOrDefault(h => h.id == idSeleccionado);

            if (habitacionesdisponibles != null && habitacionAEliminar != null)
            {
                habitacionesreservadas.Add(habitacionAEliminar);
                LB_HabSeleccionadas.DataSource = null;
                LB_HabSeleccionadas.DataSource = habitacionesreservadas;
                LB_HabSeleccionadas.DisplayMember = "id";
                LB_HabSeleccionadas.ValueMember = "id";

                habitacionesdisponibles.Remove(habitacionAEliminar);
                LB_MostrarHabitaciones.DataSource = null;
                LB_MostrarHabitaciones.DataSource = habitacionesdisponibles;
                LB_MostrarHabitaciones.DisplayMember = "id";
                LB_MostrarHabitaciones.ValueMember = "id";

                int cantPer = int.TryParse(TB_CantidadPersonas.Text, out var cp) ? cp : 0;
                cantidadpersonas += cantPer;

                habitacionesReservadasConPersonas.Add((habitacionAEliminar, cantPer));

                TB_CantidadPersonas.Text = "";
                BTN_AgregarHabitacion.Enabled = false;
            }
            if (LB_HabSeleccionadas.Items.Count > 0)
            {
                BTN_Reservar.Enabled = true;
            }
        }

        private void ValidarAnticipo(decimal anticipo)
        {
            if (anticipo < anticipofijo)
            {
                MessageBox.Show("El anticipo debe ser mayor a " + anticipofijo);
                TB_Anticipo.Focus();
            }
            else
            {
                BTN_Reservar.Enabled = true;
            }
        }


        private void TB_Anticipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    anticipo = ObtenerAnticipoLimpio();
                    ValidarAnticipo(anticipo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    TB_Anticipo.Focus();
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BTN_Reservar_Click(object sender, EventArgs e)
        {

            if (
                clientid == null ||
                hotelid == null ||
                cantidadpersonas == null ||
                anticipo == null ||
                habitacionesreservadas.Count == 0
             )
            {
                MessageBox.Show("Todos los campos deben estar llenos");
                return;
            }   

            try
            {
                using (var DB = new ApplicationDbContext())
                {
                    var nuevaReservacion = new Reservacion
                    {
                        OperativoId = empleado.GetId(),
                        ClienteId = clientid, 
                        HotelId = hotelid, 
                        CantPersonas = cantidadpersonas,
                        Anticipo = 1000.00m,
                        FechaEnt = DTP_FechaEntrada.Value.Date.AddHours(14),
                        FechaSal = DTP_FechaSalida.Value.Date.AddHours(12),
                        FechaReserva = DateTime.Now,
                        CheckInRealizado = false,
                        HabitacionReservada = new List<HabitacionReservada>()
                    };

                    int totalPorHabitaciones = habitacionesReservadasConPersonas.Sum(x => x.cantidadPersonas);
                    if (totalPorHabitaciones != cantidadpersonas)
                    {
                        MessageBox.Show("El total de personas por habitación no coincide con el total general.");
                        return;
                    }

                    foreach (var tuple in habitacionesReservadasConPersonas)
                    {
                        var habitacion = tuple.habitacion;
                        var personas = tuple.cantidadPersonas;

                        nuevaReservacion.HabitacionReservada.Add(new HabitacionReservada
                        {
                            HabitacionId = habitacion.id,
                            CantidadPersonas = personas
                        });
                    }


                    DB.Reservaciones.Add(nuevaReservacion);
                    DB.SaveChanges();
                    MessageBox.Show($"Reservación registrada por el operativo {empleado.GetNombreCompleto()}. El codigo de reserva es el siguiente {nuevaReservacion.CodigoReserva.ToString()}");

                    this.Hide();
                    var nuevoFormulario = new Reservaciones();
                    nuevoFormulario.Show();
                    this.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show($"Hubo un error {err}");
                Debug.WriteLine(err);
                return;
            }
        }

        private void LB_HabSeleccionadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LB_HabSeleccionadas.SelectedItem is Habitaciones habreservada)
            {
                BTN_EliminarHab.Enabled = true;
            }
        }

        private void BTN_EliminarHab_Click(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(LB_HabSeleccionadas.SelectedValue);
            var habitacionAEliminar = habitacionesreservadas.FirstOrDefault(h => h.id == idSeleccionado);
            if (habitacionesreservadas != null && habitacionAEliminar != null)
            {
                habitacionesdisponibles.Add(habitacionAEliminar);
                var entrada = habitacionesReservadasConPersonas
                    .FirstOrDefault(x => x.habitacion.id == idSeleccionado);
                if (entrada.habitacion != null)
                {
                    habitacionesReservadasConPersonas.Remove(entrada);
                    cantidadpersonas -= entrada.cantidadPersonas;
                }
                LB_MostrarHabitaciones.DataSource = null;
                LB_MostrarHabitaciones.DataSource = habitacionesdisponibles;
                LB_MostrarHabitaciones.DisplayMember = "id";
                LB_MostrarHabitaciones.ValueMember = "id";

                habitacionesreservadas.Remove(habitacionAEliminar);
                LB_HabSeleccionadas.DataSource = null;
                LB_HabSeleccionadas.DataSource = habitacionesreservadas;
                LB_HabSeleccionadas.DisplayMember = "id";
                LB_HabSeleccionadas.ValueMember = "id";

                BTN_EliminarHab.Enabled = false;
            }
            if (LB_HabSeleccionadas.Items.Count == 0)
            {
                TB_Anticipo.Enabled = false;
                TB_Anticipo.Text = "";
                BTN_Reservar.Enabled = false;
            }
        }

        private void TB_Anticipo_TextChanged(object sender, EventArgs e)
        {
            if (isFormatting) return; 

            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
                return;
            int selectionStart = textBox.SelectionStart;
            int lengthBefore = textBox.Text.Length;
            string onlyDigits = new string(textBox.Text.Where(char.IsDigit).ToArray());

            if (decimal.TryParse(onlyDigits, out decimal value))
            {
                isFormatting = true; 
                value /= 100;
                textBox.Text = value.ToString("C2", new CultureInfo("es-MX"));
                int lengthAfter = textBox.Text.Length;
                selectionStart += (lengthAfter - lengthBefore);
                if (selectionStart < 0) selectionStart = 0;
                if (selectionStart > textBox.Text.Length) selectionStart = textBox.Text.Length;
                textBox.SelectionStart = selectionStart;
                isFormatting = false; 
            }
        }

        private void RTB_MostrarAMHabitaciones_TextChanged(object sender, EventArgs e)
        {

        }

        private void LV_MostrarCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
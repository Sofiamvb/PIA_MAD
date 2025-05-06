using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using PIA_MAD.Clases;
using System.Globalization;
using System.Xml;


namespace PIA_MAD
{

    public partial class Registro_de_habitaciones : Form
    {
        private string patronNumeros = @"^\d+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronPrecio = @"^\$\d{1,3}(,\d{3})*(\.\d{2})?$";
        bool isFormatting = false;
        private bool _comboBoxCargado = false;
        private int cantidaddisponiblehab;
        private List<string> listaCaracteristicas = new List<string>();
        private List<string> listaAmenidades = new List<string>();
        Empleado empleado = Empleado.ObtenerInstancia();
        private void ActualizarDisponibilidad()
        {
            if (CB_RegHotelDHb.SelectedItem is Hoteles hotel)
            {
                using (var context = new ApplicationDbContext())
                {
                    int ocupadas = context.Habitaciones.Count(h => h.HotelId == hotel.id);
                    cantidaddisponiblehab = hotel.cantHab - ocupadas;
                    LBL_CantHabDisponible.Text = cantidaddisponiblehab.ToString();
                }
            }
        }

        private void LimpiarFormulario()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox tb)
                    tb.Text = "";
                else if (c is ComboBox cb)
                    cb.SelectedIndex = 0;
                else if (c is DateTimePicker dtp)
                    dtp.Value = DateTime.Now;
            }

            ActualizarDisponibilidad();
        }

        public Registro_de_habitaciones()
        {
            InitializeComponent();
            DTP_RegHab.ShowUpDown = true;
            DTP_RegHab.Enabled = false;
            using (var context = new ApplicationDbContext())
            {
                var Hoteles = context.Hoteles.FromSqlRaw("SELECT * FROM dbo.Hoteles").ToList();

                CB_RegHotelDHb.DataSource = Hoteles;
                CB_RegHotelDHb.DisplayMember = "Nombre";
                CB_RegHotelDHb.ValueMember = "id";

            }
            _comboBoxCargado = true;
            string[] opNivelHab = { "Estandar", "Deluxe", "Ejecutiva", "Suite" };
            CB_regNvHab.Items.AddRange(opNivelHab);

            string[] TCama = { "Individual", "Matrimonial", "Sofá cama", "Queen", "King" };
            CB_TipoCHab.Items.AddRange(TCama);

            _comboBoxCargado = true;

            if (CB_RegHotelDHb.Items.Count > 0)
                CB_RegHotelDHb.SelectedIndex = 0;

            if (CB_regNvHab.Items.Count > 0)
                CB_regNvHab.SelectedIndex = 0;

            if (CB_TipoCHab.Items.Count > 0)
                CB_TipoCHab.SelectedIndex = 0;

            ActualizarDisponibilidad();

            LV_MostrarChar.View = View.Details;
            LV_MostrarChar.FullRowSelect = true;
            LV_MostrarChar.GridLines = true;
            LV_MostrarChar.Columns.Clear();
            LV_MostrarChar.Columns.Add("Nombre", 160);

            LV_MostrarAm.View = View.Details;
            LV_MostrarAm.FullRowSelect = true;
            LV_MostrarAm.GridLines = true;
            LV_MostrarAm.Columns.Clear();
            LV_MostrarAm.Columns.Add("Nombre", 160);

            BTN_AgregarChar.Enabled = false;
            BTN_AgregarAm.Enabled = false;

            BTN_EliminarChar.Enabled = false;
            BTN_EliminarAm.Enabled = false;

            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private decimal ObtenerNumeroLimpio(string numero)
        {
            // Elimina todos los símbolos de moneda y separadores
            string texto = numero.Replace("$", "").Replace(",", "").Trim();

            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultado))
            {
                return resultado;
            }
            else
            {
                throw new Exception("Anticipo inválido");
            }
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaHoteles = null;
        }

        private void LV_MostrarAm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_MostrarAm.SelectedItems.Count > 0)
            {
                BTN_EliminarAm.Enabled = true;
            }
            else
            {
                BTN_EliminarAm.Enabled = false;
            }
        }

        private void BTN_EliminarAm_Click(object sender, EventArgs e)
        {
            if (LV_MostrarAm.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in LV_MostrarAm.SelectedItems)
                {
                    string valor = item.Text;
                    listaAmenidades.Remove(valor);
                    LV_MostrarAm.Items.Remove(item);
                }

                BTN_EliminarAm.Enabled = false;
            }
        }

        private void TB_RegAmeHb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!Regex.IsMatch(TB_RegAmeHb.Text, patronNombre))
                {
                    MessageBox.Show("La amenidad solo puede tener letras y espacios");
                    return;
                }
                if (string.IsNullOrWhiteSpace(TB_RegAmeHb.Text))
                {
                    MessageBox.Show("No puedes dejar vacio este campo");
                    return;
                }
                BTN_AgregarAm.Enabled = true;
            }
        }

        private void BTN_AgregarAm_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TB_RegAmeHb.Text, patronNombre))
            {
                MessageBox.Show("La amenidad solo puede tener letras y espacios");
                return;
            }
            if (string.IsNullOrWhiteSpace(TB_RegAmeHb.Text))
            {
                MessageBox.Show("No puedes dejar vacio este campo");
                return;
            }
            string nuevaam = TB_RegAmeHb.Text.Trim();

            listaAmenidades.Add(nuevaam);

            // Agrega al ListView
            LV_MostrarAm.Items.Add(nuevaam);

            // Limpia el textbox y desactiva el botón
            TB_RegAmeHb.Text = "";
            BTN_AgregarAm.Enabled = false;
        }

        private void LV_MostrarChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_MostrarChar.SelectedItems.Count > 0)
            {
                BTN_EliminarChar.Enabled = true;
            }
            else
            {
                BTN_EliminarChar.Enabled = false;
            }
        }

        private void BTN_EliminarChar_Click(object sender, EventArgs e)
        {
            if (LV_MostrarChar.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in LV_MostrarChar.SelectedItems)
                {
                    string valor = item.Text;
                    listaCaracteristicas.Remove(valor);
                    LV_MostrarChar.Items.Remove(item);
                }

                BTN_EliminarChar.Enabled = false;
            }
        }

        private void TB_RegCaractHb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!Regex.IsMatch(TB_RegCaractHb.Text, patronNombre))
                {
                    MessageBox.Show("La caracteristica solo puede tener letras y espacios.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(TB_RegCaractHb.Text))
                {
                    MessageBox.Show("No puedes dejar vacio este campo");
                    return;
                }
                BTN_AgregarChar.Enabled = true;
            }
        }

        private void BTN_AgregarChar_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TB_RegCaractHb.Text, patronNombre))
            {
                MessageBox.Show("La caracteristica solo puede tener letras y espacios.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TB_RegCaractHb.Text))
            {
                MessageBox.Show("No puedes dejar vacio este campo");
                return;
            }
            string nuevochar = TB_RegCaractHb.Text.Trim();

            listaCaracteristicas.Add(nuevochar);

            // Agrega al ListView
            LV_MostrarChar.Items.Add(nuevochar);

            // Limpia el textbox y desactiva el botón
            TB_RegCaractHb.Text = "";
            BTN_AgregarChar.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int HotelDHb = (int)CB_RegHotelDHb.SelectedValue;
            string NvHab = CB_regNvHab.SelectedItem.ToString();
            string TipoC = CB_TipoCHab.SelectedItem.ToString();
            string CantHabHb = TB_RegCantHhb.Text;
            string NumCHb = TB_RegNumCHb.Text;
            string PrecioNHb = TB_RegPNHb.Text;

            string CapHb = TB_RegCapHb.Text;
            string VistaHb = TB_RegVistaHb.Text;
            string AmeHb = string.Join(",", listaAmenidades);
            string CaractHb = string.Join(",", listaCaracteristicas);
            DateTime FechNaHb = DTP_RegHab.Value;
            if (
                HotelDHb == null ||
                NvHab == null ||
                TipoC == null ||
                string.IsNullOrWhiteSpace(CantHabHb) ||
                CantHabHb == "0" ||
                string.IsNullOrWhiteSpace(NumCHb) ||
                string.IsNullOrWhiteSpace(PrecioNHb) ||
                string.IsNullOrWhiteSpace(CapHb) ||
                string.IsNullOrWhiteSpace(VistaHb) ||
                string.IsNullOrWhiteSpace(AmeHb) ||
                string.IsNullOrWhiteSpace(CaractHb)
            )
            {
                MessageBox.Show("Todos los elementos deben tener un valor");
                return;
            }
            if (!Regex.IsMatch(CantHabHb, patronNumeros))
            {
                MessageBox.Show("La cantidad de habitaciones debe ser un numero");
                return;
            }
            if (!Regex.IsMatch(NumCHb, patronNumeros))
            {
                MessageBox.Show("El numero de camas debe ser un numero");
                return;
            }
            if (!Regex.IsMatch(PrecioNHb, patronPrecio))
            {
                MessageBox.Show("El precio por noche debe ser un numero");
                return;
            }
            if (!Regex.IsMatch(CapHb, patronNumeros))
            {
                MessageBox.Show("La cantidad de personas por habitacion debe ser un numero");
                return;
            }
            if (!Regex.IsMatch(VistaHb, patronNombre))
            {
                MessageBox.Show("La vista debe tener solo letras y espacios");
                return;
            }

            try
            {

                int CantHab = Int32.Parse(CantHabHb);
                int NoCamas = Int32.Parse(NumCHb);
                decimal PrecioNoche = ObtenerNumeroLimpio(PrecioNHb);
                int Capacidad = Int32.Parse(CapHb);

                using (var context = new ApplicationDbContext())
                {
                    for (int i = 1; i <= CantHab; i++)
                    {
                        var Hab = new Habitaciones
                        {
                            FechaRegistro = FechNaHb,
                            HotelId = HotelDHb,
                            CreadorAdministradorId = empleado.GetId(),
                            ModificadorAdministradorId = empleado.GetId(),
                            NoCamas = NoCamas,
                            tipoCama = TipoC,
                            PrecioNoche = PrecioNoche,
                            Capacidad = Capacidad,
                            nivelHab = NvHab,
                            Vista = VistaHb,
                            Amenidades = AmeHb,
                            caracteristicas = CaractHb,
                            Disponible = true,
                            FechaModificacion = DateTime.Now,
                        };

                        context.Habitaciones.Add(Hab);
                    }
                    context.SaveChanges();

                    MessageBox.Show($"El usuario: {empleado.GetNombreCompleto()} con Rol: {empleado.GetRol()} ha registrado habitaciones.");

                    this.Hide();
                    var nuevoFormulario = new Registro_de_habitaciones();
                    nuevoFormulario.Show();
                    this.Close();
                }


            }
            catch (FormatException error)
            {
                Debug.WriteLine(error.Message);
            }
        }

        private void CB_RegHotelDHb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_comboBoxCargado) return;

            var hotelseleccionado = CB_RegHotelDHb.SelectedItem as Hoteles;
            if (hotelseleccionado != null)
            {
                using (var DB = new ApplicationDbContext())
                {
                    int cantidadocupada = DB.Habitaciones.Where(h => h.HotelId == hotelseleccionado.id).Count();
                    cantidaddisponiblehab = hotelseleccionado.cantHab - cantidadocupada;
                    Debug.WriteLine(cantidaddisponiblehab);
                    LBL_CantHabDisponible.Text = cantidaddisponiblehab.ToString();
                }
            }
        }

        private void Registro_de_habitaciones_Load(object sender, EventArgs e)
        {

        }

        private void TB_RegCantHhb_TextChanged(object sender, EventArgs e)
        {
            if (cantidaddisponiblehab <= 0)
                return;
            try
            {
                string CantHabHb = TB_RegCantHhb.Text;
                if (string.IsNullOrWhiteSpace(CantHabHb))
                {
                    CantHabHb = "0";
                }

                int canthab = Int32.Parse(CantHabHb);
                int result = cantidaddisponiblehab - canthab;
                Debug.WriteLine(result);

                if (result < 0)
                {
                    Debug.WriteLine($"Dentro del if. Resultado: {result}");
                    MessageBox.Show("Número no válido, tiene que ser menor o igual a la disponibilidad.");
                    TB_RegCantHhb.Text = "0";
                }
            }
            catch (FormatException error)
            {
                MessageBox.Show("Formato no válido, tiene que ser un número", error.Message);
                TB_RegCantHhb.Text = "0";
            }
        }

        private void TB_RegPNHb_TextChanged(object sender, EventArgs e)
        {
            if (isFormatting) return; // Si estamos formateando, no hacer nada

            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text))
                return;

            // Guardar posición del cursor
            int selectionStart = textBox.SelectionStart;
            int lengthBefore = textBox.Text.Length;

            // Eliminar cualquier símbolo que no sea número
            string onlyDigits = new string(textBox.Text.Where(char.IsDigit).ToArray());

            if (decimal.TryParse(onlyDigits, out decimal value))
            {
                isFormatting = true; // Evitar reentradas

                // Dividir para respetar dos decimales
                value /= 100;

                // Formatear
                textBox.Text = value.ToString("C2", new CultureInfo("es-MX"));

                // Restaurar cursor (ajustar por diferencia de longitud)
                int lengthAfter = textBox.Text.Length;
                selectionStart += (lengthAfter - lengthBefore);
                if (selectionStart < 0) selectionStart = 0;
                if (selectionStart > textBox.Text.Length) selectionStart = textBox.Text.Length;
                textBox.SelectionStart = selectionStart;

                isFormatting = false; // Volver a permitir formateo
            }
        }
    }
}

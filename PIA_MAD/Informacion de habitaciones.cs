using Microsoft.EntityFrameworkCore;
using PIA_MAD.Clases;
using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class Informacion_de_habitaciones : Form
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
        private int habitacionId;
        public Informacion_de_habitaciones(Habitaciones habitacion, string nombreHotel)
        {
            InitializeComponent();
            this.habitacionId = habitacion.id;
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

            CB_RegHotelDHb.Items.Add(nombreHotel);
            if (CB_RegHotelDHb.Items.Count > 0)
                CB_RegHotelDHb.SelectedIndex = 0;
            CB_RegHotelDHb.Enabled = false;

            TB_RegNumCHb.Text = habitacion.NoCamas.ToString();

            string[] TCama = { "Individual", "Matrimonial", "Sofá cama", "Queen", "King" };
            CB_TipoCHab.Items.AddRange(TCama);

            int index = Array.IndexOf(TCama, habitacion.tipoCama);
            if (index >= 0)
                CB_TipoCHab.SelectedIndex = index;
            else
                CB_TipoCHab.SelectedIndex = 0;

            TB_RegPNHb.Text = habitacion.PrecioNoche.ToString();

            TB_RegCapHb.Text = habitacion.Capacidad.ToString();

            string[] opNivelHab = { "Estandar", "Deluxe", "Ejecutiva", "Suite" };
            CB_regNvHab.Items.AddRange(opNivelHab);

            int index1 = Array.IndexOf(TCama, habitacion.nivelHab);
            if (index1 >= 0)
                CB_regNvHab.SelectedIndex = index;
            else
                CB_regNvHab.SelectedIndex = 0;

            TB_RegVistaHb.Text = habitacion.Vista;

            var listaCaracteristicas = habitacion.caracteristicas.Split(',');
            var listaAmenidades = habitacion.Amenidades.Split(',');

            foreach (var item in listaCaracteristicas)
            {
                var listItem = new ListViewItem(item.Trim());
                LV_MostrarChar.Items.Add(listItem);

                this.listaCaracteristicas.Add(item.Trim());

            }
            foreach (var item in listaAmenidades)
            {
                var listItem = new ListViewItem(item.Trim());
                LV_MostrarAm.Items.Add(listItem);
                this.listaAmenidades.Add(item.Trim());
            }
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
            GestorVentanasAdm.VentanaInformacionHabitaciones = null;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string NvHab = CB_regNvHab.SelectedItem.ToString();
            string TipoC = CB_TipoCHab.SelectedItem.ToString();
            string NumCHb = TB_RegNumCHb.Text;
            string PrecioNHb = TB_RegPNHb.Text;

            string CapHb = TB_RegCapHb.Text;
            string VistaHb = TB_RegVistaHb.Text;
            string AmeHb = string.Join(",", listaAmenidades);
            string CaractHb = string.Join(",", listaCaracteristicas);
            DateTime FechNaHb = DTP_RegHab.Value;
            if (
                NvHab == null ||
                TipoC == null ||
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
                int NoCamas = Int32.Parse(NumCHb);
                decimal PrecioNoche = ObtenerNumeroLimpio(PrecioNHb);
                int Capacidad = Int32.Parse(CapHb);

                using (var context = new ApplicationDbContext())
                {
                    context.Database.ExecuteSqlRaw(@"
                        UPDATE Habitaciones
                        SET 
                            ModificadorAdministradorId = {0},
                            NoCamas = {1},
                            tipoCama = {2},
                            PrecioNoche = {3},
                            Capacidad = {4},
                            nivelHab = {5},
                            Vista = {6},
                            Amenidades = {7},
                            caracteristicas = {8},
                            FechaModificacion = {9}
                        WHERE id = {10}",
                        empleado.GetId(),
                        NoCamas,
                        TipoC,
                        PrecioNoche,
                        Capacidad,
                        NvHab,
                        VistaHb,
                        AmeHb,
                        CaractHb,
                        DateTime.Now,
                        habitacionId
                    );

                    MessageBox.Show($"El usuario: {empleado.GetNombreCompleto()} con Rol: {empleado.GetRol()} ha actualizado una habitación.");

                    this.Hide();
                    var nuevoFormulario = new Modificar_Habitaciones();
                    nuevoFormulario.Show();
                    this.Close();
                }


            }
            catch (FormatException error)
            {
                Debug.WriteLine(error.Message);
            }
        }
    }
}

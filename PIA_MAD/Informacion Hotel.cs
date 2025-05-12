using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using PIA_MAD.Clases;
using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class Informacion_Hotel : Form
    {
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronNumeros = @"^\d+$";
        private string caracteristicas;
        private string amenidades;
        private int hotelId;
        private string NombreServicio;
        private int PrecioServicio;
        private List<string> listaCaracteristicas = new List<string>();
        private List<string> listaAmenidades = new List<string>();
        private List<ServicioAdicionalHotel> servicioAdicionalHotel = new List<ServicioAdicionalHotel>();
        Empleado empleado = Empleado.ObtenerInstancia();
        public Informacion_Hotel(Hoteles hotel)
        {
            InitializeComponent();
            this.hotelId = hotel.id;
            DTP_RegHotel.ShowUpDown = true;
            DTP_RegHotel.Enabled = false;
            TB_RegServAdHPr.Enabled = false;

            BTN_AgregarServicio.Enabled = false;
            BTN_EliminarServicio.Enabled = false;

            BTN_AgregarChar.Enabled = false;
            BTN_AgregarAm.Enabled = false;

            BTN_EliminarChar.Enabled = false;
            BTN_EliminarAm.Enabled = false;



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

            LV_ServiciosAgregados.View = View.Details;
            LV_ServiciosAgregados.FullRowSelect = true;
            LV_ServiciosAgregados.GridLines = true;
            LV_ServiciosAgregados.Columns.Clear();
            LV_ServiciosAgregados.Columns.Add("Nombre", 220);
            LV_ServiciosAgregados.Columns.Add("Precio", 80);

            var listaCaracteristicas = hotel.caracteristicas.Split(',');
            var listaAmenidades = hotel.amenidades.Split(',');

            TB_RegNomH.Text = hotel.Nombre;
            TB_RegPaisH.Text = hotel.pais;
            TB_RegEstH.Text = hotel.estado;
            TB_RegCuH.Text = hotel.ciudad;
            TB_RegDomH.Text = hotel.domicilio;
            TB_RegNumPH.Text = hotel.Pisos.ToString();
            TB_RegChabH.Text = hotel.cantHab.ToString();
            if(hotel.ZonaTur == true)
            {
                ChB_RegZTH.Checked = true; 
            }else
            {
                ChB_RegZTH.Checked = false;
            }
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
            if (hotel.ServiciosAdicionales != null && hotel.ServiciosAdicionales.Any())
            {
                foreach (var servicio in hotel.ServiciosAdicionales)
                {
                    var item = new ListViewItem(servicio.Nombre);
                    item.SubItems.Add(servicio.Precio.ToString("C")); 
       
                    item.Tag = servicio.id;

                    LV_ServiciosAgregados.Items.Add(item);

                    servicioAdicionalHotel.Add(servicio);
                }
            }
            if (hotel.FrentePlaya == true)
            {
                ChB_RegFrentePlayaH.Checked = true;
            }
            else
            {
                ChB_RegFrentePlayaH.Checked = false;
            }
            TB_RegCantPisH.Text = hotel.CantPiscina.ToString();
            if (hotel.SalonEv == true) {
                RB_SEventSi.Checked = true;
                RB_SEventNo.Checked = false;
            }else
            {
                RB_SEventSi.Checked = false;
                RB_SEventSi.Checked = true;
            }

            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaInformacion_Hotel = null;
        }

        private void Informacion_Hotel_Load(object sender, EventArgs e)
        {

        }

        private void TB_RegServAdH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!Regex.IsMatch(TB_RegServAdH.Text, patronNombre))
                {
                    MessageBox.Show("El servicio adicional solo puede tener letras y espacios");
                    return;
                }
                if (string.IsNullOrWhiteSpace(TB_RegServAdH.Text))
                {
                    TB_RegServAdH.Text = NombreServicio;
                    MessageBox.Show("No puedes dejar vacio este campo");
                    return;
                }
                TB_RegServAdHPr.Enabled = true;
                NombreServicio = TB_RegServAdH.Text;
            }
        }

        private void TB_RegServAdHPr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (string.IsNullOrWhiteSpace(TB_RegServAdHPr.Text))
                {
                    MessageBox.Show("No puedes dejar vacio este campo");
                    TB_RegServAdHPr.Text = "0";
                    return;
                }
                try
                {
                    PrecioServicio = Int32.Parse(TB_RegServAdHPr.Text);
                    BTN_AgregarServicio.Enabled = true;
                }
                catch (FormatException err)
                {
                    MessageBox.Show("Formato no valido, tiene que ser un numero");
                    return;
                }
            }
        }

        private void TB_RegChar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!Regex.IsMatch(TB_RegChar.Text, patronNombre))
                {
                    MessageBox.Show("La caracteristica solo puede tener letras y espacios");
                    return;
                }
                if (string.IsNullOrWhiteSpace(TB_RegChar.Text))
                {
                    MessageBox.Show("No puedes dejar vacio este campo");
                    return;
                }
                BTN_AgregarChar.Enabled = true;
            }
        }

        private void BTN_AgregarChar_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TB_RegChar.Text, patronNombre))
            {
                MessageBox.Show("La caracteristica solo puede tener letras y espacios");
                return;
            }
            if (string.IsNullOrWhiteSpace(TB_RegChar.Text))
            {
                MessageBox.Show("No puedes dejar vacio este campo");
                return;
            }
            string nuevochar = TB_RegChar.Text.Trim();

            listaCaracteristicas.Add(nuevochar);

            LV_MostrarChar.Items.Add(nuevochar);

            TB_RegChar.Text = "";
            BTN_AgregarChar.Enabled = false;
        }

        private void TB_RegAm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!Regex.IsMatch(TB_RegAm.Text, patronNombre))
                {
                    MessageBox.Show("La amenidad solo puede tener letras y espacios.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(TB_RegAm.Text))
                {
                    MessageBox.Show("No puedes dejar vacio este campo");
                    return;
                }
                BTN_AgregarAm.Enabled = true;
            }
        }

        private void BTN_AgregarAm_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TB_RegAm.Text, patronNombre))
            {
                MessageBox.Show("La amenidad solo puede tener letras y espacios.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TB_RegAm.Text))
            {
                MessageBox.Show("No puedes dejar vacio este campo");
                return;
            }
            string nuevaam = TB_RegAm.Text.Trim();

            listaAmenidades.Add(nuevaam);

            LV_MostrarAm.Items.Add(nuevaam);

            TB_RegAm.Text = "";
            BTN_AgregarAm.Enabled = false;
        }

        private void BTN_AgregarServicio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_RegServAdH.Text) || string.IsNullOrWhiteSpace(TB_RegServAdHPr.Text))
            {
                MessageBox.Show("Los campos no pueden estar vacíos");
                return;
            }

            if (!int.TryParse(TB_RegServAdHPr.Text, out int precio))
            {
                MessageBox.Show("El precio debe ser un número válido");
                return;
            }
            if (!Regex.IsMatch(TB_RegServAdH.Text, patronNombre))
            {
                MessageBox.Show("El servicio adicional solo puede tener letras y espacios");
                return;
            }

            NombreServicio = TB_RegServAdH.Text;
            PrecioServicio = precio;

            var servicioAdicional = new ServicioAdicionalHotel
            {
                Nombre = NombreServicio,
                Precio = PrecioServicio
            };
            servicioAdicionalHotel.Add(servicioAdicional);

            TB_RegServAdH.Text = "";
            TB_RegServAdHPr.Text = "";
            TB_RegServAdHPr.Enabled = false;
            BTN_AgregarServicio.Enabled = false;

            LV_ServiciosAgregados.Items.Clear();
            foreach (var servicio in servicioAdicionalHotel)
            {
                ListViewItem item = new ListViewItem(servicio.Nombre);
                item.SubItems.Add($"${servicio.Precio}");
                LV_ServiciosAgregados.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NombreH = TB_RegNomH.Text;
            string PaisH = TB_RegPaisH.Text;
            string EstH = TB_RegEstH.Text;
            string CiudadH = TB_RegCuH.Text;
            string NumPiso = TB_RegNumPH.Text;
            string CantHabH = TB_RegChabH.Text;
            string CantPiscinaH = TB_RegCantPisH.Text;
            string DomH = TB_RegDomH.Text;
            string CaractH = string.Join(",", listaCaracteristicas);
            string AmeH = string.Join(",", listaAmenidades);
            string CantPiscinas = TB_RegCantPisH.Text;
            DateTime FechNaH = DTP_RegHotel.Value;
            bool ChZonaT = ChB_RegZTH.Checked;
            bool ChFrentePlaya = ChB_RegFrentePlayaH.Checked;
            bool RBSEvent = false;
            if (RB_SEventSi.Checked)
            {
                RBSEvent = true;
            }
            if (RB_SEventNo.Checked)
            {
                RBSEvent = false;
            }
            if (
                string.IsNullOrWhiteSpace(NombreH) ||
                string.IsNullOrWhiteSpace(PaisH) ||
                string.IsNullOrWhiteSpace(EstH) ||
                string.IsNullOrWhiteSpace(CiudadH) ||
                string.IsNullOrWhiteSpace(NumPiso) ||
                string.IsNullOrWhiteSpace(CantHabH) ||
                string.IsNullOrWhiteSpace(CantPiscinaH) ||
                string.IsNullOrWhiteSpace(DomH) ||
                string.IsNullOrWhiteSpace(CaractH) ||
                string.IsNullOrWhiteSpace(AmeH) ||
                string.IsNullOrWhiteSpace(CantPiscinas) ||
                ChZonaT == null ||
                ChFrentePlaya == null ||
                RBSEvent == null
            )
            {
                MessageBox.Show("Todos los campos tienen que estar completos");
                return;
            }
            if (!Regex.IsMatch(PaisH, patronNombre))
            {
                MessageBox.Show("El Pais solo puede tener letras y espacios");
                return;
            }
            if (!Regex.IsMatch(EstH, patronNombre))
            {
                MessageBox.Show("El Estado solo puede tener letras y espacios");
                return;
            }
            if (!Regex.IsMatch(CiudadH, patronNombre))
            {
                MessageBox.Show("La Ciudad solo puede tener letras y espacios");
                return;
            }
            if (!Regex.IsMatch(CantHabH, patronNumeros))
            {
                MessageBox.Show("La cantidad de habitaciones solo puede tener numeros");
                return;
            }
            if (!Regex.IsMatch(CantPiscinas, patronNumeros))
            {
                MessageBox.Show("La cantidad de piscinas solo puede tener numeros");
                return;
            }
            if (!Regex.IsMatch(NumPiso, patronNumeros))
            {
                MessageBox.Show("El numero de pisos solo puede tener numeros");
                return;
            }
            try
            {

                int PisoH = Int32.Parse(NumPiso);
                int CantHabitacion = Int32.Parse(CantHabH);
                int CantPiscina = Int32.Parse(CantPiscinaH);
                using (var context = new ApplicationDbContext())
                {
                    context.Database.ExecuteSqlRaw(@"
                        UPDATE Hoteles
                        SET 
                            Nombre = {0},
                            pais = {1},
                            estado = {2},
                            ciudad = {3},
                            domicilio = {4},
                            Pisos = {5},
                            cantHab = {6},
                            CantPiscina = {7},
                            caracteristicas = {8},
                            amenidades = {9},
                            ZonaTur = {10},
                            FrentePlaya = {11},
                            SalonEv = {12},
                            FechaModificacion = {13},
                            ModificadorAdministradorId = {14}
                        WHERE id = {15}",
                        NombreH, PaisH, EstH, CiudadH, DomH,
                        PisoH, CantHabitacion, CantPiscina,
                        CaractH, AmeH,
                        ChZonaT, ChFrentePlaya, RBSEvent,
                        DateTime.Now, empleado.GetId(),
                        hotelId
                    );
                    foreach (var servicio in servicioAdicionalHotel)
                    {
                        context.Database.ExecuteSqlRaw(@"
                            INSERT INTO ServiciosAdicionalesHotel (HotelId, Nombre, Precio)
                            VALUES ({0}, {1}, {2})",
                            hotelId, servicio.Nombre, servicio.Precio);
                    }
                    context.SaveChanges();

                    MessageBox.Show($"El usuario: {empleado.GetNombreCompleto()} con Rol: {empleado.GetRol()} actualizo un hotel.");


                    this.Hide();
                    var nuevoFormulario = new Mod_Hotel();
                    nuevoFormulario.Show();
                    this.Close();
                }

            }
            catch (FormatException error)
            {
                MessageBox.Show("Solo números son válidos", error.Message);
            }


        }


        private void LV_ServiciosAgregados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_ServiciosAgregados.SelectedItems.Count > 0)
            {
                BTN_EliminarServicio.Enabled = true;
            }
            else
            {
                BTN_EliminarServicio.Enabled = false;
            }
        }

        private void BTN_EliminarServicio_Click(object sender, EventArgs e)
        {
            if (LV_ServiciosAgregados.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un servicio para eliminar.");
                return;
            }

            foreach (ListViewItem item in LV_ServiciosAgregados.SelectedItems)
            {
                string nombre = item.SubItems[0].Text;

                var servicioAEliminar = servicioAdicionalHotel.FirstOrDefault(s => s.Nombre == nombre);
                if (servicioAEliminar != null)
                {
                    servicioAdicionalHotel.Remove(servicioAEliminar);
                }

                LV_ServiciosAgregados.Items.Remove(item);
            }

            BTN_EliminarServicio.Enabled = false;
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
    }
}

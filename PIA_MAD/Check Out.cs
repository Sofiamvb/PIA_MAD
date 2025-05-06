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

namespace PIA_MAD
{
    public partial class Check_Out : Form
    {
        private int descuento;
        private decimal descuentoAplicable;
        private decimal montoTotal;
        private decimal montoDescuento;
        private Guid codigoreserva;
        private List<ServicioAdicionalHotel> servicioAdicionalHotel = new List<ServicioAdicionalHotel>();
        private List<ServicioAdicionalHotel> servicioAdicionalesSeleccionados = new List<ServicioAdicionalHotel>();
        public Check_Out()
        {
            InitializeComponent();
            DTP_CheckOut.ShowUpDown = true;
            DTP_CheckOut.Enabled = false;
            RB_DescuentoSi.Enabled = false;
            RB_DescuentoNo.Enabled = false;
            TB_CantDescuento.Enabled = false;
            TB_MontoTotal.Enabled = false;
            TB_AnticipoCO.Enabled = false;
            BTN_CheckOut.Enabled = false;
            BTN_Factura.Enabled = false;
            BTN_AgregarServicio.Enabled = false;
            BTN_EliminarServicio.Enabled = false;


            LV_ServiciosAdicionales.View = View.Details;
            LV_ServiciosAdicionales.FullRowSelect = true;
            LV_ServiciosAdicionales.GridLines = true;
            LV_ServiciosAdicionales.Columns.Clear();
            LV_ServiciosAdicionales.Columns.Add("Nombre", 220);
            LV_ServiciosAdicionales.Columns.Add("Precio", 80);

            LV_ServiciosAgregados.View = View.Details;
            LV_ServiciosAgregados.FullRowSelect = true;
            LV_ServiciosAgregados.GridLines = true;
            LV_ServiciosAgregados.Columns.Clear();
            LV_ServiciosAgregados.Columns.Add("Nombre", 220);
            LV_ServiciosAgregados.Columns.Add("Precio", 80);

            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuSuperior());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanas.VentanaClientes = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Check_Out_Load(object sender, EventArgs e)
        {

        }

        private void TB_NumReserva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                string checkin_code = TB_NumReserva.Text;
                using (var DB = new ApplicationDbContext())
                {
                    if (Guid.TryParse(checkin_code, out codigoreserva))
                    {
                        var resultado = DB.Reservaciones
                            .Where(r => r.CodigoReserva == codigoreserva)
                            .SelectMany(r => r.HabitacionReservada.Select(hr => new
                            {
                                HotelId = hr.Habitacion.HotelId,
                                Anticipo = r.Anticipo,
                                ServiciosAdicionales = hr.Habitacion.Hotel.ServiciosAdicionales,
                                PrecioNoche = hr.Habitacion.PrecioNoche
                            }))
                            .ToList(); // Si hay varias habitaciones, obtendrás una lista


                        if (resultado.Count == 0)
                        {
                            MessageBox.Show("Codigo no valido, intenta de nuevo.");
                            return;
                        }

                        var hotelId = resultado[0].HotelId;
                        var anticipo = resultado[0].Anticipo;
                        var servicios = resultado[0].ServiciosAdicionales;
                        decimal totalPorNoche = resultado.Sum(x => x.PrecioNoche);
                        montoTotal = montoTotal + totalPorNoche;
                        montoTotal = montoTotal - anticipo;
                        TB_MontoTotal.Text = montoTotal.ToString();

                        RB_DescuentoSi.Enabled = true;
                        RB_DescuentoNo.Enabled = true;

                        BTN_CheckOut.Enabled = true;
                        BTN_Factura.Enabled = true;

                        TB_AnticipoCO.Text = anticipo.ToString();
                        var serviciosadicionales = servicios;

                        servicioAdicionalHotel = serviciosadicionales;

                        LV_ServiciosAdicionales.Items.Clear();

                        foreach (var servicio in servicioAdicionalHotel)
                        {
                            var item = new ListViewItem(servicio.Nombre); // Columna 0

                            // Puedes agregar subitems (columnas adicionales)
                            item.SubItems.Add(servicio.Precio.ToString()); // Columna 1

                            // Opcional: almacenar el ID en la propiedad Tag
                            item.Tag = servicio.id;

                            LV_ServiciosAdicionales.Items.Add(item);
                        }

                        MessageBox.Show("Numero de reserva Valido");
                    }
                    else
                    {
                        MessageBox.Show("El código ingresado no es válido.");
                        return;
                    }
                }
            }
        }

        private void BTN_CheckOut_Click(object sender, EventArgs e)
        {

        }

        private void RB_DescuentoSi_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_DescuentoSi.Checked)
            {
                TB_CantDescuento.Enabled = true;
                TB_CantDescuento.Text = "0";
                MessageBox.Show("Se aplicará el descuento.");
            }
            else if (RB_DescuentoNo.Checked)
            {
                TB_CantDescuento.Enabled = false;
                TB_CantDescuento.Text = "0";
                TB_MontoTotal.Text = montoTotal.ToString();
                MessageBox.Show("No se aplicará el descuento.");
            }
        }

        private void LV_ServiciosAdicionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_ServiciosAdicionales.SelectedItems.Count > 0)
            {
                BTN_AgregarServicio.Enabled = true;
            }
        }

        private void BTN_AgregarServicio_Click(object sender, EventArgs e)
        {
            if (LV_ServiciosAdicionales.SelectedItems.Count > 0)
            {
                var itemsToRemove = new List<ListViewItem>();

                foreach (ListViewItem item in LV_ServiciosAdicionales.SelectedItems)
                {
                    int servicioId = (int)item.Tag;
                    var servicio = servicioAdicionalHotel.FirstOrDefault(s => s.id == servicioId);

                    if (servicio != null)
                    {
                        servicioAdicionalHotel.Remove(servicio);
                        servicioAdicionalesSeleccionados.Add(servicio);

                        montoTotal = montoTotal + servicio.Precio;
                        TB_MontoTotal.Text = montoTotal.ToString();
                        // Agregar a la lista de agregados
                        var nuevoItem = new ListViewItem(servicio.Nombre);
                        nuevoItem.SubItems.Add(servicio.Precio.ToString());
                        nuevoItem.Tag = servicio.id;
                        LV_ServiciosAgregados.Items.Add(nuevoItem);

                        // Marcar para quitar del original
                        itemsToRemove.Add(item);
                    }
                }

                // Quitar los seleccionados del listview original
                foreach (var item in itemsToRemove)
                {
                    LV_ServiciosAdicionales.Items.Remove(item);
                }

                BTN_AgregarServicio.Enabled = false;
                BTN_EliminarServicio.Enabled = true;
            }
            else
            {
                MessageBox.Show("Debes seleccionar al menos un servicio adicional para agregarlo.");
                return;
            }
        }


        private void LV_ServiciosAgregados_SelectedIndexChanged(object sender, EventArgs e)
        {
            BTN_EliminarServicio.Enabled = LV_ServiciosAgregados.SelectedItems.Count > 0;
        }

        private void BTN_EliminarServicio_Click(object sender, EventArgs e)
        {
            if (LV_ServiciosAgregados.SelectedItems.Count > 0)
            {
                var itemsToRemove = new List<ListViewItem>();

                foreach (ListViewItem item in LV_ServiciosAgregados.SelectedItems)
                {
                    int servicioId = (int)item.Tag;
                    var servicio = servicioAdicionalesSeleccionados.FirstOrDefault(s => s.id == servicioId);

                    if (servicio != null)
                    {
                        servicioAdicionalesSeleccionados.Remove(servicio);
                        servicioAdicionalHotel.Add(servicio);
                        montoTotal = montoTotal - servicio.Precio;
                        TB_MontoTotal.Text = montoTotal.ToString();
                        // Regresar al listview original
                        var nuevoItem = new ListViewItem(servicio.Nombre);
                        nuevoItem.SubItems.Add(servicio.Precio.ToString());
                        nuevoItem.Tag = servicio.id;
                        LV_ServiciosAdicionales.Items.Add(nuevoItem);

                        // Marcar para quitar
                        itemsToRemove.Add(item);
                    }
                }

                // Quitar de la lista agregada
                foreach (var item in itemsToRemove)
                {
                    LV_ServiciosAgregados.Items.Remove(item);
                }

                BTN_EliminarServicio.Enabled = false;
                BTN_AgregarServicio.Enabled = true;
            }
            else
            {
                MessageBox.Show("Selecciona al menos un servicio para eliminarlo.");
            }
        }

        private void TB_CantDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                try
                {
                    descuento = Int32.Parse(TB_CantDescuento.Text);
                    if (descuento < 0)
                    {
                        MessageBox.Show("El descuento tiene que ser mayor a 0%");
                        TB_CantDescuento.Text = "0";
                        TB_MontoTotal.Text = montoTotal.ToString();
                        return;
                    }
                    if (descuento > 100)
                    {
                        MessageBox.Show("El descuento no puede ser mayor a 100%");
                        TB_CantDescuento.Text = "0";
                        TB_MontoTotal.Text = montoTotal.ToString();
                        return;
                    }
                    descuentoAplicable = montoTotal * (descuento / 100m);
                    montoDescuento = montoTotal - descuentoAplicable;
                    TB_MontoTotal.Text = montoDescuento.ToString();
                }
                catch (FormatException err)
                {
                    MessageBox.Show("El descuento tiene que ser un porcentaje");
                    TB_CantDescuento.Text = "0";
                    return;
                }

            }
        }
    }
}

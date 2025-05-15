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
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using PIA_MAD.Clases;

namespace PIA_MAD
{
    public partial class Reporte_de_ventas : Form
    {
        private string pais;
        private string ciudad;
        private string anio;
        private int anioNum;
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        public Reporte_de_ventas()
        {
            InitializeComponent();

            BTN_Filtrar.Enabled = false;

            CB_Hoteles.Enabled = false;

            LBL_IngresosTotales.Visible = false;
            LBL_IngresosHospedaje.Visible = false;
            LBL_IngresosServicios.Visible = false;

            LV_ReporteVentas.View = View.Details;
            LV_ReporteVentas.FullRowSelect = true;
            LV_ReporteVentas.GridLines = true;
            LV_ReporteVentas.Columns.Clear();
            LV_ReporteVentas.Columns.Add("Tipo", 80);
            LV_ReporteVentas.Columns.Add("Nombre", 100);
            LV_ReporteVentas.Columns.Add("Ciudad", 100);
            LV_ReporteVentas.Columns.Add("Año", 60);
            LV_ReporteVentas.Columns.Add("Mes", 60);
            LV_ReporteVentas.Columns.Add("Monto", 100);
            LV_ReporteVentas.Columns.Add("Anticipo", 100);
            LV_ReporteVentas.Columns.Add("Descuento", 100);
            LV_ReporteVentas.Columns.Add("Servicios adicionales", 100);
            LV_ReporteVentas.Columns.Add("Total Venta", 80);

            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaHoteles = null;
        }
        private void ObtenerTodo()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var reporte = context.Vista_VentasYAnticipos
                        .OrderBy(r => r.Anio)
                        .ThenBy(r => r.Mes)
                        .ToList();

                    LV_ReporteVentas.Items.Clear();

                    foreach (var item in reporte)
                    {
                        decimal totalVenta = item.Monto + item.Anticipo + item.ServiciosAdicionales - item.CantidadDescuento;

                        var listItem = new ListViewItem(item.Tipo);
                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.Ciudad);
                        listItem.SubItems.Add(item.Anio.ToString());
                        listItem.SubItems.Add(item.Mes);
                        listItem.SubItems.Add(item.Monto.ToString("C"));
                        listItem.SubItems.Add(item.Anticipo.ToString("C"));
                        listItem.SubItems.Add(item.CantidadDescuento.ToString("C"));
                        listItem.SubItems.Add(item.ServiciosAdicionales.ToString("C"));
                        listItem.SubItems.Add(totalVenta.ToString("C"));

                        LV_ReporteVentas.Items.Add(listItem);
                    }

                    var totalGeneral = reporte.Sum(r =>
                        r.Tipo == "Venta"
                            ? (r.Monto + r.Anticipo + r.ServiciosAdicionales)
                            : r.Tipo == "Anticipo"
                                ? r.Anticipo
                                : 0);

                    var totalHospedaje = reporte.Sum(r =>
                        r.Tipo == "Venta"
                            ? (r.Monto + r.Anticipo)
                            : r.Tipo == "Anticipo"
                                ? r.Anticipo
                                : 0);

                    var totalServicios = reporte
                        .Where(r => r.Tipo == "Venta")
                        .Sum(r => r.ServiciosAdicionales);

                    LBL_IngresosTotales.Text = $"Ingresos totales: {totalGeneral.ToString("C")} MXN";
                    LBL_IngresosHospedaje.Text = $"Ingresos hospedaje: {totalHospedaje.ToString("C")} MXN";
                    LBL_IngresosServicios.Text = $"Ingresos servicios: {totalServicios.ToString("C")} MXN";

                    LBL_IngresosTotales.Visible = true;
                    LBL_IngresosHospedaje.Visible = true;
                    LBL_IngresosServicios.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error: {ex.Message}");
                return;
            }
        }

        private void Reporte_de_ventas_Load(object sender, EventArgs e)
        {
            ObtenerTodo();
        }

        private void BTN_Filtrar_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                var resultados = db.VentasYAnticiposView
                        .FromSqlRaw("SELECT * FROM dbo.GetVentasYAnticiposPorHotelAnio({0}, {1}, {2}, {3})",
                            pais, ciudad, anio, (object)DBNull.Value)
                        .ToList();

                if (resultados.Count > 0)
                {
                    LV_ReporteVentas.Items.Clear();

                    foreach (var item in resultados)
                    {
                        var listItem = new ListViewItem(item.Tipo);

                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.Ciudad);
                        listItem.SubItems.Add(item.Anio.ToString());
                        listItem.SubItems.Add(item.Mes.ToString());
                        listItem.SubItems.Add(item.Monto.ToString("C"));
                        listItem.SubItems.Add(item.Anticipo.ToString("C"));
                        listItem.SubItems.Add(item.CantidadDescuento.ToString("C"));
                        listItem.SubItems.Add(item.ServiciosAdicionales.ToString("C"));
                        listItem.SubItems.Add((item.Monto + item.Anticipo + item.ServiciosAdicionales).ToString("C"));

                        LV_ReporteVentas.Items.Add(listItem);
                    }

                    var totalGeneral = resultados.Sum(r =>
                        r.Tipo == "Venta"
                            ? (r.Monto + r.Anticipo + r.ServiciosAdicionales)
                            : r.Tipo == "Anticipo"
                                ? r.Anticipo
                                : 0);

                    var totalHospedaje = resultados.Sum(r =>
                        r.Tipo == "Venta" ? (r.Monto + r.Anticipo) :
                        r.Tipo == "Anticipo" ? r.Anticipo : 0);

                    var totalServicios = resultados
                        .Where(r => r.Tipo == "Venta")
                        .Sum(r => r.ServiciosAdicionales);

                    string ingresosTotales = Utilidades.FormatearComoMoneda(totalGeneral);
                    string ingresosHospedaje = Utilidades.FormatearComoMoneda(totalHospedaje);
                    string ingresosServicios = Utilidades.FormatearComoMoneda(totalServicios);

                    LBL_IngresosTotales.Text = $"Ingresos totales: {ingresosTotales} MXN";
                    LBL_IngresosHospedaje.Text = $"Ingresos hospedaje: {ingresosHospedaje} MXN";
                    LBL_IngresosServicios.Text = $"Ingresos servicios: {ingresosServicios} MXN";

                    LBL_IngresosTotales.Visible = true;
                    LBL_IngresosHospedaje.Visible = true;
                    LBL_IngresosServicios.Visible = true;

                    var hoteles = db.HotelesPorUbicacion
                        .FromSqlRaw("SELECT * FROM dbo.GetHotelesPorPaisCiudad({0}, {1})", pais, ciudad)
                        .OrderBy(h => h.Nombre)
                        .ToList();

                    var listaCombo = new List<KeyValuePair<int?, string>>
                    {
                        new KeyValuePair<int?, string>(null, "Todos")
                    };

                    listaCombo.AddRange(hoteles.Select(h => new KeyValuePair<int?, string>(h.id, h.Nombre)));

                    CB_Hoteles.Enabled = true;
                    CB_Hoteles.DisplayMember = "Value";
                    CB_Hoteles.ValueMember = "Key";
                    CB_Hoteles.DataSource = listaCombo;

                }
                else
                {
                    MessageBox.Show("Sin resultados, haz otra busqueda con otro pais o ciudad");
                    return;
                }
            }
        }

        private void TB_Pais_TextChanged(object sender, EventArgs e)
        {
            pais = TB_Pais.Text;
            if (!Regex.IsMatch(pais, patronNombre))
            {
                MessageBox.Show("El pais solo puede tener letras");
                return;
            }
            if (!string.IsNullOrEmpty(pais) && !string.IsNullOrEmpty(ciudad) && !string.IsNullOrEmpty(anio))
            {
                BTN_Filtrar.Enabled = true;
            }
        }

        private void TB_Ciudad_TextChanged(object sender, EventArgs e)
        {
            ciudad = TB_Ciudad.Text;
            if (!Regex.IsMatch(ciudad, patronNombre))
            {
                MessageBox.Show("La ciudad solo puede tener letras");
                return;
            }
            if (!string.IsNullOrEmpty(pais) && !string.IsNullOrEmpty(ciudad) && !string.IsNullOrEmpty(anio))
            {
                BTN_Filtrar.Enabled = true;
            }
        }

        private void TB_Anio_TextChanged(object sender, EventArgs e)
        {
            anio = TB_Anio.Text;
            try
            {
                anioNum = Int32.Parse(anio);
                if (!string.IsNullOrEmpty(pais) && !string.IsNullOrEmpty(ciudad) && !string.IsNullOrEmpty(anio))
                {
                    BTN_Filtrar.Enabled = true;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("El año solo puede ser un numero");
                return;
            }
        }

        private void CB_Hoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hotelId = CB_Hoteles.SelectedValue as int?;

            using (var db = new ApplicationDbContext())
            {
                var resultados = db.VentasYAnticiposView
                    .FromSqlRaw("SELECT * FROM dbo.GetVentasYAnticiposPorHotelAnio({0}, {1}, {2}, {3})",
                        pais, ciudad, anio, hotelId ?? (object)DBNull.Value)
                    .ToList();

                LV_ReporteVentas.Items.Clear();

                foreach (var item in resultados)
                {
                    var listItem = new ListViewItem(item.Tipo);

                    listItem.SubItems.Add(item.NombreHotel);
                    listItem.SubItems.Add(item.Ciudad);
                    listItem.SubItems.Add(item.Anio.ToString());
                    listItem.SubItems.Add(item.Mes.ToString());
                    listItem.SubItems.Add(item.Monto.ToString("C"));
                    listItem.SubItems.Add(item.Anticipo.ToString("C"));
                    listItem.SubItems.Add(item.CantidadDescuento.ToString("C"));
                    listItem.SubItems.Add(item.ServiciosAdicionales.ToString("C"));
                    listItem.SubItems.Add((item.Monto + item.ServiciosAdicionales +  item.Anticipo).ToString("C"));

                    LV_ReporteVentas.Items.Add(listItem);
                }

                var totalGeneral = resultados.Sum(r =>
                    r.Tipo == "Venta"
                        ? (r.Monto + r.Anticipo + r.ServiciosAdicionales)
                        : r.Tipo == "Anticipo"
                            ? r.Anticipo
                            : 0);

                var totalHospedaje = resultados.Sum(r =>
                    r.Tipo == "Venta" ? (r.Monto + r.Anticipo) :
                    r.Tipo == "Anticipo" ? r.Anticipo : 0);

                var totalServicios = resultados
                    .Where(r => r.Tipo == "Venta")
                    .Sum(r => r.ServiciosAdicionales);

                string ingresosTotales = Utilidades.FormatearComoMoneda(totalGeneral);
                string ingresosHospedaje = Utilidades.FormatearComoMoneda(totalHospedaje);
                string ingresosServicios = Utilidades.FormatearComoMoneda(totalServicios);

                LBL_IngresosTotales.Text = $"Ingresos totales: {ingresosTotales} MXN";
                LBL_IngresosHospedaje.Text = $"Ingresos hospedaje: {ingresosHospedaje} MXN";
                LBL_IngresosServicios.Text = $"Ingresos servicios: {ingresosServicios} MXN";

            }

        }

        private void BTN_ObtenerTodo_Click(object sender, EventArgs e)
        {
            ObtenerTodo();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PIA_MAD.Clases;
using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class Historial_del_cliente : Form
    {
        private string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        private string patronRFC = @"^[A-Za-z]{4}[0-9]{6}[A-Za-z0-9]{3}$";
        private string datoBusqueda;
        private int clienteId;
        private int anioSeleccionado;
        List<HistorialClienteDTO> historial = new List<HistorialClienteDTO>();
        List<Usuario> usuarios = new();
        public Historial_del_cliente()
        {
            InitializeComponent();
            BTN_Busqueda.Enabled = false;

            CB_Anio.Enabled = false;
            CB_Anio.Items.Clear();
            CB_Anio.Items.Add("Todos");
            int anioActual = DateTime.Now.Year;
            for (int anio = 2000; anio <= anioActual; anio++)
            {
                CB_Anio.Items.Add(anio.ToString());
            }
            CB_Anio.SelectedIndex = 0;

            BTN_Filtrar.Enabled = false;

            LV_Clientes.View = View.Details;
            LV_Clientes.FullRowSelect = true;
            LV_Clientes.GridLines = true;
            LV_Clientes.Columns.Clear();
            LV_Clientes.Columns.Add("Id", 100);
            LV_Clientes.Columns.Add("Nombre", 100);
            LV_Clientes.Columns.Add("A. paterno", 100);
            LV_Clientes.Columns.Add("A. materno", 100);
            LV_Clientes.Columns.Add("Correo", 100);
            LV_Clientes.Columns.Add("Celular", 100);
            LV_Clientes.Columns.Add("RFC", 100);
            LV_Clientes.Columns.Add("Fecha de nacimiento", 60);

            LV_Historial.View = View.Details;
            LV_Historial.FullRowSelect = true;
            LV_Historial.GridLines = true;
            LV_Historial.Columns.Clear();
            LV_Historial.Columns.Add("Cliente", 100);
            LV_Historial.Columns.Add("Ciudad Hotel", 100);
            LV_Historial.Columns.Add("Hotel", 100);
            LV_Historial.Columns.Add("Tipo de habitacion", 100);
            LV_Historial.Columns.Add("Num. Habitacion", 100);
            LV_Historial.Columns.Add("Cantidad personas Hospedadas", 100);
            LV_Historial.Columns.Add("Codigo de reservacion", 100);
            LV_Historial.Columns.Add("Fecha reserva", 100);
            LV_Historial.Columns.Add("Fecha Check In", 100);
            LV_Historial.Columns.Add("Fecha Check Out", 100);
            LV_Historial.Columns.Add("Status", 100);
            LV_Historial.Columns.Add("Anticipo", 100);
            LV_Historial.Columns.Add("Monto de hospedaje", 100);
            LV_Historial.Columns.Add("Monto de servicios", 100);
            LV_Historial.Columns.Add("Monto de descuento", 100);
            LV_Historial.Columns.Add("Total Factura", 100);

            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaHoteles = null;
        }

        private void Historial_del_cliente_Load(object sender, EventArgs e)
        {
            LV_Clientes.MultiSelect = false;
        }

        private void LlenarListViewCliente(List<Usuario> clientes)
        {
            LV_Clientes.Items.Clear();
            foreach (var item in clientes)
            {
                var listItem = new ListViewItem(item.id.ToString());
                listItem.SubItems.Add(item.Nombre);
                listItem.SubItems.Add(item.AP);
                listItem.SubItems.Add(item.AM);
                listItem.SubItems.Add(item.Correo);
                listItem.SubItems.Add(item.Celular);
                listItem.SubItems.Add(item.RFC);
                listItem.SubItems.Add(item.fechaNa.ToString());

                LV_Clientes.Items.Add(listItem);
            }
        }

        private void BTN_Busqueda_Click(object sender, EventArgs e)
        {

            using (var context = new ApplicationDbContext())
            {
                if (Regex.IsMatch(datoBusqueda, patronCorreo))
                {
                    usuarios = context.Usuarios
                        .Where(u => u.Correo.ToLower() == datoBusqueda.ToLower())
                        .ToList();
                    if (usuarios.Count > 0)
                    {
                        LlenarListViewCliente(usuarios);
                        CB_Anio.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No hubo resultado en la busqueda");
                        return;
                    }
                }
                if (Regex.IsMatch(datoBusqueda, patronRFC))
                {
                    usuarios = context.Usuarios
                        .Where(u => u.RFC.ToUpper() == datoBusqueda.ToUpper())
                        .ToList();
                    if (usuarios.Count > 0)
                    {
                        LlenarListViewCliente(usuarios);
                        CB_Anio.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No hubo resultado en la busqueda");
                        return;
                    }
                }
                if (Regex.IsMatch(datoBusqueda, patronNombre))
                {
                    string[] parteDatosBusqueda = datoBusqueda.Split(" ");
                    string paterno = parteDatosBusqueda.Length > 0 ? parteDatosBusqueda[0] : "";
                    string materno = parteDatosBusqueda.Length > 1 ? parteDatosBusqueda[1] : "";

                    usuarios = context.Usuarios
                        .Where(u =>
                            u.AP.ToLower() == (paterno.ToLower()) &&
                            u.AM.ToLower() == (materno.ToLower()))
                        .ToList();
                    if (usuarios.Count > 0)
                    {
                        LlenarListViewCliente(usuarios);
                        CB_Anio.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No hubo resultado en la busqueda");
                        return;
                    }
                }
            }
        }

        private void TB_Busqueda_TextChanged(object sender, EventArgs e)
        {
            datoBusqueda = TB_Busqueda.Text;
            if (!string.IsNullOrEmpty(datoBusqueda))
            {
                BTN_Busqueda.Enabled = true;
            }
            else
            {
                BTN_Busqueda.Enabled = false;
            }
        }

        private void LV_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (LV_Clientes.SelectedItems.Count > 0)
            {
                var selectedItem = LV_Clientes.SelectedItems[0];
                clienteId = int.Parse(selectedItem.SubItems[0].Text);
                BTN_Filtrar.Enabled = true;
            }
        }

        private void LlenarListViewHistorial(List<HistorialClienteDTO> historialCliente)
        {
            LV_Historial.Items.Clear();

            foreach (var item in historialCliente)
            {
                var listItem = new ListViewItem(item.Cliente);
                listItem.SubItems.Add(item.CiudadHotel);
                listItem.SubItems.Add(item.Hotel);
                listItem.SubItems.Add(item.TipoHabitacion);
                listItem.SubItems.Add(item.NumHabitacion.ToString());
                listItem.SubItems.Add(item.CantidadPersonas.ToString());
                listItem.SubItems.Add(item.CodigoReservacion.ToString());
                listItem.SubItems.Add(item.FechaReserva.ToShortDateString());
                listItem.SubItems.Add(item.FechaCheckIn.ToShortDateString());
                listItem.SubItems.Add(item.FechaCheckOut.ToShortDateString());
                listItem.SubItems.Add(item.Status);
                listItem.SubItems.Add(item.Anticipo.ToString("C"));
                listItem.SubItems.Add(item.MontoHospedaje.ToString("C"));
                listItem.SubItems.Add(item.MontoServicios.ToString("C"));
                listItem.SubItems.Add(item.MontoDescuento.ToString("C"));
                listItem.SubItems.Add(item.TotalFactura.ToString("C"));

                LV_Historial.Items.Add(listItem);
            }
            historial.Clear();
        }


        private void BTN_Filtrar_Click(object sender, EventArgs e)
        {
            anioSeleccionado = 0;
            bool filtrarPorAnio = false;
            historial.Clear();

            if (CB_Anio.SelectedItem != null && !CB_Anio.Text.Equals("Todos"))
            {
                if (int.TryParse(CB_Anio.SelectedItem.ToString(), out anioSeleccionado))
                {
                    filtrarPorAnio = true;
                }
                else
                {
                    MessageBox.Show("Año inválido seleccionado.");
                    return;
                }
            }
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    if (filtrarPorAnio) {
                        var historialReservaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialReservacionesCliente({0}, {1})", clienteId, anioSeleccionado)
                        .ToList();
                        historial.AddRange(historialReservaciones);

                        var historialCheckOut = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCheckOutCliente({0}, {1})", clienteId, anioSeleccionado)
                        .ToList();

                        historial.AddRange(historialCheckOut);

                        var historialCancelaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCancelacionesCliente({0}, {1})", clienteId, anioSeleccionado)
                        .ToList();
                        historial.AddRange(historialCancelaciones);
                    }
                    else
                    {
                        var historialReservaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialReservacionesCliente({0}, {1})", clienteId, null)
                        .ToList();
                        historial.AddRange(historialReservaciones);

                        var historialCheckOut = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCheckOutCliente({0}, {1})", clienteId, null)
                        .ToList();

                        historial.AddRange(historialCheckOut);

                        var historialCancelaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCancelacionesCliente({0}, {1})", clienteId, null)
                        .ToList();
                        historial.AddRange(historialCancelaciones);
                    }
                    var historialOrdenado = historial.OrderByDescending(h => h.FechaReserva).ToList();
                    LlenarListViewHistorial(historialOrdenado);
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hubo un error al recuperar el historial: {ex.Message}");
                }
        }

        private void CB_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int anioSeleccionado = 0;
            bool filtrarPorAnio = false;
            historial.Clear();

            if (CB_Anio.SelectedItem != null && !CB_Anio.Text.Equals("Todos"))
            {
                if (int.TryParse(CB_Anio.SelectedItem.ToString(), out anioSeleccionado))
                {
                    filtrarPorAnio = true;
                }
                else
                {
                    MessageBox.Show("Año inválido seleccionado.");
                    return;
                }
            }
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    if (filtrarPorAnio)
                    {
                        var historialReservaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialReservacionesCliente({0}, {1})", clienteId, anioSeleccionado)
                        .ToList();
                        historial.AddRange(historialReservaciones);

                        var historialCheckOut = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCheckOutCliente({0}, {1})", clienteId, anioSeleccionado)
                        .ToList();

                        historial.AddRange(historialCheckOut);

                        var historialCancelaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCancelacionesCliente({0}, {1})", clienteId, anioSeleccionado)
                        .ToList();
                        historial.AddRange(historialCancelaciones);
                    }
                    else
                    {
                        var historialReservaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialReservacionesCliente({0}, {1})", clienteId, null)
                        .ToList();
                        historial.AddRange(historialReservaciones);

                        var historialCheckOut = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCheckOutCliente({0}, {1})", clienteId, null)
                        .ToList();

                        historial.AddRange(historialCheckOut);

                        var historialCancelaciones = _context.HistorialCliente
                        .FromSqlRaw("SELECT * FROM dbo.GetHistorialCancelacionesCliente({0}, {1})", clienteId, null)
                        .ToList();
                        historial.AddRange(historialCancelaciones);
                    }
                    var historialOrdenado = historial.OrderByDescending(h => h.FechaReserva).ToList();
                    LlenarListViewHistorial(historialOrdenado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al recuperar el historial: {ex.Message}");
            }
        }
    }
}

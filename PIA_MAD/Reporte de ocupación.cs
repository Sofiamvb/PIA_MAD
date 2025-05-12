using Microsoft.EntityFrameworkCore;
using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class Reporte_de_ocupación : Form
    {
        private string pais;
        private string ciudad;
        private string anio;
        private int anioNum;
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        public Reporte_de_ocupación()
        {
            InitializeComponent();

            BTN_Filtrar.Enabled = false;

            CB_Hoteles.Enabled = false;

            LV_InfoCompleta.View = View.Details;
            LV_InfoCompleta.FullRowSelect = true;
            LV_InfoCompleta.GridLines = true;
            LV_InfoCompleta.Columns.Clear();
            LV_InfoCompleta.Columns.Add("Ciudad", 100);
            LV_InfoCompleta.Columns.Add("Nombre", 100);
            LV_InfoCompleta.Columns.Add("Año", 100);
            LV_InfoCompleta.Columns.Add("Mes", 100);
            LV_InfoCompleta.Columns.Add("Tipo de habitacion", 100);
            LV_InfoCompleta.Columns.Add("Cantidad de habitaciones", 100);
            LV_InfoCompleta.Columns.Add("Porcentaje de ocupacion", 60);
            LV_InfoCompleta.Columns.Add("Cantidad de personas hospedas", 60);

            LV_Resumen.View = View.Details;
            LV_Resumen.FullRowSelect = true;
            LV_Resumen.GridLines = true;
            LV_Resumen.Columns.Clear();
            LV_Resumen.Columns.Add("Ciudad", 100);
            LV_Resumen.Columns.Add("Nombre", 100);
            LV_Resumen.Columns.Add("Año", 100);
            LV_Resumen.Columns.Add("Mes", 100);
            LV_Resumen.Columns.Add("Porcentaje de ocupacion", 100);


            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaHoteles = null;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Reporte_de_ocupación_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Filtrar_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                var resultados = db.ReporteOcupacionView
                    .FromSqlRaw("SELECT * FROM dbo.GetReporteOcupacionPorHotelAnio({0}, {1}, {2}, {3})",
                        pais, ciudad, anio, (object)DBNull.Value)
                    .ToList();

                if (resultados.Count > 0)
                {
                    LV_InfoCompleta.Items.Clear();

                    var agrupado = resultados
                        .GroupBy(r => new
                        {
                            r.HotelId,
                            r.NombreHotel,
                            r.Ciudad,
                            r.Anio,
                            r.Mes,
                            r.TipoHabitacion
                        })
                        .Select(g => new
                        {
                            g.Key.HotelId,
                            g.Key.NombreHotel,
                            g.Key.Ciudad,
                            g.Key.Anio,
                            g.Key.Mes,
                            g.Key.TipoHabitacion,
                            TotalNoches = g.Sum(x => x.NochesOcupadas),
                            TotalPersonas = g.Sum(x => x.Personas),
                            CantidadHabitaciones = g.Count() 
                        })
                        .ToList();

                    foreach (var item in agrupado)
                    {
                        var listItem = new ListViewItem(item.Ciudad);
                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.Anio.ToString());
                        listItem.SubItems.Add(item.Mes);
                        listItem.SubItems.Add(item.TipoHabitacion);
                        listItem.SubItems.Add(item.CantidadHabitaciones.ToString());
                        int diasMes = DateTime.DaysInMonth(item.Anio, DateTime.ParseExact(item.Mes, "MMMM", CultureInfo.InvariantCulture).Month);
                        int totalHabxDias = item.CantidadHabitaciones * diasMes;
                        string porcentaje = totalHabxDias > 0
                            ? ((decimal)item.TotalNoches / totalHabxDias).ToString("P1")
                            : "N/A";

                        listItem.SubItems.Add(porcentaje);
                        listItem.SubItems.Add(item.TotalPersonas.ToString());

                        LV_InfoCompleta.Items.Add(listItem);
                    }

                    LV_Resumen.Items.Clear();

                    var resumenAgrupado = agrupado
                        .GroupBy(x => new { x.Ciudad, x.NombreHotel, x.Anio, x.Mes })
                        .Select(g => new
                        {
                            Ciudad = g.Key.Ciudad,
                            NombreHotel = g.Key.NombreHotel,
                            Anio = g.Key.Anio,
                            Mes = g.Key.Mes,
                            TotalNoches = g.Sum(x => x.TotalNoches),
                            TotalHab = g.Sum(x => x.CantidadHabitaciones)
                        })
                        .ToList();

                    foreach (var item in resumenAgrupado)
                    {
                        int diasMes = DateTime.DaysInMonth(item.Anio, DateTime.ParseExact(item.Mes, "MMMM", CultureInfo.InvariantCulture).Month);
                        int totalHabxDias = item.TotalHab * diasMes;
                        string porcentaje = totalHabxDias > 0
                            ? ((decimal)item.TotalNoches / totalHabxDias).ToString("P1")
                            : "N/A";

                        var listItem = new ListViewItem(item.Ciudad);
                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.Anio.ToString());
                        listItem.SubItems.Add(item.Mes);
                        listItem.SubItems.Add(porcentaje);

                        LV_Resumen.Items.Add(listItem);
                    }


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
                    MessageBox.Show("No hay datos para el filtro seleccionado.");
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
                var resultados = db.ReporteOcupacionView
                    .FromSqlRaw("SELECT * FROM dbo.GetReporteOcupacionPorHotelAnio({0}, {1}, {2}, {3})",
                        pais, ciudad, anio, hotelId ?? (object)DBNull.Value)
                    .ToList();

                if (resultados.Count > 0)
                {
                    LV_InfoCompleta.Items.Clear();
                    var agrupado = resultados
                        .GroupBy(r => new
                        {
                            r.HotelId,
                            r.NombreHotel,
                            r.Ciudad,
                            r.Anio,
                            r.Mes,
                            r.TipoHabitacion
                        })
                        .Select(g => new
                        {
                            g.Key.HotelId,
                            g.Key.NombreHotel,
                            g.Key.Ciudad,
                            g.Key.Anio,
                            g.Key.Mes,
                            g.Key.TipoHabitacion,
                            TotalNoches = g.Sum(x => x.NochesOcupadas),
                            TotalPersonas = g.Sum(x => x.Personas),
                            CantidadHabitaciones = g.Count() 
                        })
                        .ToList();

                    foreach (var item in agrupado)
                    {
                        var listItem = new ListViewItem(item.Ciudad);
                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.Anio.ToString());
                        listItem.SubItems.Add(item.Mes);
                        listItem.SubItems.Add(item.TipoHabitacion);
                        listItem.SubItems.Add(item.CantidadHabitaciones.ToString());

                        int diasMes = DateTime.DaysInMonth(item.Anio, DateTime.ParseExact(item.Mes, "MMMM", CultureInfo.InvariantCulture).Month);
                        int totalHabxDias = item.CantidadHabitaciones * diasMes;
                        string porcentaje = totalHabxDias > 0
                            ? ((decimal)item.TotalNoches / totalHabxDias).ToString("P1")
                            : "N/A";

                        listItem.SubItems.Add(porcentaje);
                        listItem.SubItems.Add(item.TotalPersonas.ToString());

                        LV_InfoCompleta.Items.Add(listItem);
                    }

                    LV_Resumen.Items.Clear();

                    var resumenAgrupado = agrupado
                        .GroupBy(x => new { x.Ciudad, x.NombreHotel, x.Anio, x.Mes })
                        .Select(g => new
                        {
                            Ciudad = g.Key.Ciudad,
                            NombreHotel = g.Key.NombreHotel,
                            Anio = g.Key.Anio,
                            Mes = g.Key.Mes,
                            TotalNoches = g.Sum(x => x.TotalNoches),
                            TotalHab = g.Sum(x => x.CantidadHabitaciones)
                        })
                        .ToList();

                    foreach (var item in resumenAgrupado)
                    {
                        int diasMes = DateTime.DaysInMonth(item.Anio, DateTime.ParseExact(item.Mes, "MMMM", CultureInfo.InvariantCulture).Month);
                        int totalHabxDias = item.TotalHab * diasMes;
                        string porcentaje = totalHabxDias > 0
                            ? ((decimal)item.TotalNoches / totalHabxDias).ToString("P1")
                            : "N/A";

                        var listItem = new ListViewItem(item.Ciudad);
                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.Anio.ToString());
                        listItem.SubItems.Add(item.Mes);
                        listItem.SubItems.Add(porcentaje);

                        LV_Resumen.Items.Add(listItem);
                    }


                }
                else
                {
                    MessageBox.Show("No hay datos para el hotel seleccionado.");
                    return;
                }
            }
        }
    }
}

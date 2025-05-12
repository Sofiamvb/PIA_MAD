using Microsoft.EntityFrameworkCore;
using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class Mod_Hotel : Form
    {
        private int hotelId;
        private string busqueda;
        public Mod_Hotel()
        {
            InitializeComponent();

            BTN_Modificar.Enabled = false;

            LV_Hoteles.MultiSelect = false;

            LV_Hoteles.View = View.Details;
            LV_Hoteles.FullRowSelect = true;
            LV_Hoteles.GridLines = true;
            LV_Hoteles.Columns.Clear();
            LV_Hoteles.Columns.Add("Id", 100);
            LV_Hoteles.Columns.Add("Nombre", 100);
            LV_Hoteles.Columns.Add("Pais", 100);
            LV_Hoteles.Columns.Add("Estado", 100);
            LV_Hoteles.Columns.Add("Ciudad", 100);
            LV_Hoteles.Columns.Add("Domicilio", 100);
        }

        private void BTN_Busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var hotel = context.Hoteles
                        .FirstOrDefault(h => h.Nombre == busqueda);

                    if (hotel != null)
                    {
                        LV_Hoteles.Items.Clear();
                        var listItem = new ListViewItem(hotel.id.ToString());
                        listItem.SubItems.Add(hotel.Nombre);
                        listItem.SubItems.Add(hotel.pais);
                        listItem.SubItems.Add(hotel.estado);
                        listItem.SubItems.Add(hotel.ciudad);
                        listItem.SubItems.Add(hotel.domicilio);

                        LV_Hoteles.Items.Add(listItem);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el hotel");
                        var hoteles = context.VistaHotelesUbicacion.ToList();
                        LV_Hoteles.Items.Clear();
                        foreach (var item in hoteles)
                        {
                            var listItem = new ListViewItem(item.id.ToString());
                            listItem.SubItems.Add(item.Nombre);
                            listItem.SubItems.Add(item.pais);
                            listItem.SubItems.Add(item.estado);
                            listItem.SubItems.Add(item.ciudad);
                            listItem.SubItems.Add(item.domicilio);

                            LV_Hoteles.Items.Add(listItem);
                        }
                        return;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Hubo un error: {ex.Message}");
            }
            
        }

        private void Mod_Hotel_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var hoteles = context.VistaHotelesUbicacion.ToList();

                    foreach (var item in hoteles)
                    {
                        var listItem = new ListViewItem(item.id.ToString());
                        listItem.SubItems.Add(item.Nombre);
                        listItem.SubItems.Add(item.pais);
                        listItem.SubItems.Add(item.estado);
                        listItem.SubItems.Add(item.ciudad);
                        listItem.SubItems.Add(item.domicilio);

                        LV_Hoteles.Items.Add(listItem);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al recuperar los hoteles. Error: {ex.Message}");
            }
        }

        private void LV_Hoteles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Hoteles.SelectedItems.Count > 0)
            {
                ListViewItem itemSeleccionado = LV_Hoteles.SelectedItems[0];

                hotelId = int.Parse(itemSeleccionado.SubItems[0].Text);

                BTN_Modificar.Enabled = true;
            }
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            if (hotelId == null)
            {
                MessageBox.Show("Tienes que elegir un hotel.");
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var hotel = context.Hoteles
                    .Include(h => h.ServiciosAdicionales)
                    .FirstOrDefault(h => h.id == hotelId);

                    if (hotel != null)
                    {
                        this.Hide();
                        var nuevaVentana = new Informacion_Hotel(hotel);
                        nuevaVentana.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el hotel");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error en la base de datos: {ex.Message}");
                return;
            }
        }

        private void TB_Busqueda_TextChanged(object sender, EventArgs e)
        {
            busqueda = TB_Busqueda.Text;
            if (!string.IsNullOrEmpty(busqueda))
            {
                BTN_Busqueda.Enabled = true;
            }
            else
            {
                BTN_Busqueda.Enabled = false;
            }
        }
    }
}

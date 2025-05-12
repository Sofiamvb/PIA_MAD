using Microsoft.EntityFrameworkCore;
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

namespace PIA_MAD
{
    public partial class Modificar_Habitaciones : Form
    {
        private int habitacionId;
        private string nombreHotel;
        private string busquedaString;
        private int busquedaInt;
        public Modificar_Habitaciones()
        {
            InitializeComponent();

            BTN_Busqueda.Enabled = false;
            BTN_Modificar.Enabled = false;

            LV_Habitaciones.MultiSelect = false;

            LV_Habitaciones.View = View.Details;
            LV_Habitaciones.FullRowSelect = true;
            LV_Habitaciones.GridLines = true;
            LV_Habitaciones.Columns.Clear();
            LV_Habitaciones.Columns.Add("Id", 200);
            LV_Habitaciones.Columns.Add("Hotel", 200);
            LV_Habitaciones.Columns.Add("Nivel Habitacion", 200);
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            if (habitacionId == null)
            {
                MessageBox.Show("Tienes que elegir un hotel.");
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var habitacion = context.Habitaciones
                    .FirstOrDefault(h => h.id == habitacionId);

                    if (habitacion != null)
                    {
                        this.Hide();
                        var nuevaVentana = new Informacion_de_habitaciones(habitacion, nombreHotel);
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

        private void LV_Habitaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Habitaciones.SelectedItems.Count > 0)
            {
                ListViewItem itemSeleccionado = LV_Habitaciones.SelectedItems[0];

                habitacionId = int.Parse(itemSeleccionado.SubItems[0].Text);

                nombreHotel = itemSeleccionado.SubItems[1].Text;

                BTN_Modificar.Enabled = true;
            }
        }

        private void Modificar_Habitaciones_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var habitaciones = context.VistaHabitacionesHoteles.ToList();

                    foreach (var item in habitaciones)
                    {
                        var listItem = new ListViewItem(item.HabitacionId.ToString());
                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.NivelHabitacion);

                        LV_Habitaciones.Items.Add(listItem);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al recuperar los hoteles. Error: {ex.Message}");
            }
        }

        private void BTN_Busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var habitacion = context.Habitaciones
                        .Include(h => h.Hotel)
                        .FirstOrDefault(h => h.id == busquedaInt);

                    if (habitacion != null)
                    {
                        LV_Habitaciones.Items.Clear();
                        var listItem = new ListViewItem(habitacion.id.ToString());
                        listItem.SubItems.Add(habitacion.Hotel.Nombre);
                        listItem.SubItems.Add(habitacion.nivelHab);

                        LV_Habitaciones.Items.Add(listItem);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el hotel");
                        LV_Habitaciones.Items.Clear();
                        var habitaciones = context.VistaHabitacionesHoteles.ToList();

                        foreach (var item in habitaciones)
                        {
                            var listItem = new ListViewItem(item.HabitacionId.ToString());
                            listItem.SubItems.Add(item.NombreHotel);
                            listItem.SubItems.Add(item.NivelHabitacion);

                            LV_Habitaciones.Items.Add(listItem);
                        }
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error, Error: {ex.Message}");
            }

        }

        private void TB_Busqueda_TextChanged(object sender, EventArgs e)
        {
            busquedaString = TB_Busqueda.Text;
            if (!string.IsNullOrEmpty(busquedaString))
            {
                if (int.TryParse(busquedaString, out int busqueda))
                {
                    busquedaInt = busqueda;
                    BTN_Busqueda.Enabled = true;
                }
                else
                {
                    BTN_Busqueda.Enabled = false;
                    MessageBox.Show("Tiene que ser un numero.");
                    return;
                }

            }
            else
            {
                BTN_Busqueda.Enabled = false;
            }
        }

        private void BTN_VerTodos_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var habitaciones = context.VistaHabitacionesHoteles.ToList();
                    LV_Habitaciones.Items.Clear();
                    foreach (var item in habitaciones)
                    {
                        var listItem = new ListViewItem(item.HabitacionId.ToString());
                        listItem.SubItems.Add(item.NombreHotel);
                        listItem.SubItems.Add(item.NivelHabitacion);

                        LV_Habitaciones.Items.Add(listItem);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"Hubo un error, error: {ex.Message}");
                return;
            }
        }
    }
}

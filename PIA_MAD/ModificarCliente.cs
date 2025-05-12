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
    public partial class ModificarCliente : Form
    {
        private int clienteId;
        private string busqueda;
        public ModificarCliente()
        {
            InitializeComponent();

            BTN_Modificar.Enabled = false;

            LV_Clientes.MultiSelect = false;

            LV_Clientes.View = View.Details;
            LV_Clientes.FullRowSelect = true;
            LV_Clientes.GridLines = true;
            LV_Clientes.Columns.Clear();
            LV_Clientes.Columns.Add("Id", 100);
            LV_Clientes.Columns.Add("Nombre", 100);
            LV_Clientes.Columns.Add("A. Paterno", 100);
            LV_Clientes.Columns.Add("A. Materno", 100);
            LV_Clientes.Columns.Add("Correo", 100);
            LV_Clientes.Columns.Add("Celular", 100);
            LV_Clientes.Columns.Add("RFC", 100);
            LV_Clientes.Columns.Add("Fecha NA.", 100);
        }

        private void ObtenerTodosRegistros()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var usuarios = context.VistaUsuariosSimplificada.ToList();
                    LV_Clientes.Items.Clear();

                    foreach (var usuario in usuarios)
                    {
                        var item = new ListViewItem(usuario.id.ToString());
                        item.SubItems.Add(usuario.Nombre);
                        item.SubItems.Add(usuario.AP);
                        item.SubItems.Add(usuario.AM);
                        item.SubItems.Add(usuario.Correo);
                        item.SubItems.Add(usuario.Celular);
                        item.SubItems.Add(usuario.RFC);
                        item.SubItems.Add(usuario.fechaNa.ToShortDateString());

                        LV_Clientes.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al recuperar los clientes. Error: {ex.Message}");
            }
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            ObtenerTodosRegistros();
        }

        private void LV_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Clientes.SelectedItems.Count > 0)
            {
                ListViewItem itemSeleccionado = LV_Clientes.SelectedItems[0];

                clienteId = int.Parse(itemSeleccionado.SubItems[0].Text);

                BTN_Modificar.Enabled = true;
            }
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            if (clienteId == null)
            {
                MessageBox.Show("Tienes que elegir un hotel.");
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var cliente = context.Usuarios
                    .FirstOrDefault(h => h.id == clienteId);

                    if (cliente != null)
                    {
                        this.Hide();
                        var nuevaVentana = new InformacionCliente(cliente);
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

        private void BTN_VerTodos_Click(object sender, EventArgs e)
        {
            ObtenerTodosRegistros();
        }

        private void BTN_Busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var cliente = context.Usuarios
                    .FirstOrDefault(h => h.Nombre == busqueda);

                    if (cliente != null)
                    {
                        LV_Clientes.Items.Clear();
                        var item = new ListViewItem(cliente.id.ToString());
                        item.SubItems.Add(cliente.Nombre);
                        item.SubItems.Add(cliente.AP);
                        item.SubItems.Add(cliente.AM);
                        item.SubItems.Add(cliente.Correo);
                        item.SubItems.Add(cliente.Celular);
                        item.SubItems.Add(cliente.RFC);
                        item.SubItems.Add(cliente.fechaNa.ToShortDateString());

                        LV_Clientes.Items.Add(item);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el usuario");
                        ObtenerTodosRegistros();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error: {ex.Message}");
            }
        }
    }
}

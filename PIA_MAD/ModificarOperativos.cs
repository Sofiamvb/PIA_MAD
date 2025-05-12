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
    public partial class ModificarOperativos : Form
    {
        private int operativoId;
        private string busqueda;
        public ModificarOperativos()
        {
            InitializeComponent();

            BTN_Modificar.Enabled = false;

            LV_Operativos.MultiSelect = false;

            LV_Operativos.View = View.Details;
            LV_Operativos.FullRowSelect = true;
            LV_Operativos.GridLines = true;
            LV_Operativos.Columns.Clear();
            LV_Operativos.Columns.Add("Id", 100);
            LV_Operativos.Columns.Add("Nombre", 100);
            LV_Operativos.Columns.Add("A. Paterno", 100);
            LV_Operativos.Columns.Add("A. Materno", 100);
            LV_Operativos.Columns.Add("Correo", 100);
            LV_Operativos.Columns.Add("Celular", 100);
            LV_Operativos.Columns.Add("Nomina", 100);
            LV_Operativos.Columns.Add("Fecha NA.", 100);
        }

        private void ObtenerTodosRegistros()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var operativos = context.Vista_Operativos.ToList();
                    LV_Operativos.Items.Clear();

                    foreach (var usuario in operativos)
                    {
                        var item = new ListViewItem(usuario.id.ToString());
                        item.SubItems.Add(usuario.Nombre);
                        item.SubItems.Add(usuario.AP);
                        item.SubItems.Add(usuario.AM);
                        item.SubItems.Add(usuario.Correo);
                        item.SubItems.Add(usuario.Celular);
                        item.SubItems.Add(usuario.Nomina.ToString());
                        item.SubItems.Add(usuario.fechaNa.ToShortDateString());

                        LV_Operativos.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al recuperar los operativos. Error: {ex.Message}");
            }
        }

        private void BTN_VerTodos_Click(object sender, EventArgs e)
        {
            ObtenerTodosRegistros();
        }

        private void ModificarOperativos_Load(object sender, EventArgs e)
        {
            ObtenerTodosRegistros();
        }

        private void LV_Operativos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LV_Operativos.SelectedItems.Count > 0)
            {
                ListViewItem itemSeleccionado = LV_Operativos.SelectedItems[0];

                operativoId = int.Parse(itemSeleccionado.SubItems[0].Text);

                BTN_Modificar.Enabled = true;
            }
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            if (operativoId == null)
            {
                MessageBox.Show("Tienes que elegir un hotel.");
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var operativo = context.Operativos
                    .FirstOrDefault(h => h.id == operativoId);

                    if (operativo != null)
                    {
                        this.Hide();
                        var nuevaVentana = new InformacionOperativo(operativo);
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

        private void BTN_Busqueda_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var cliente = context.Operativos
                    .FirstOrDefault(h => h.Nombre == busqueda);

                    if (cliente != null)
                    {
                        LV_Operativos.Items.Clear();
                        var item = new ListViewItem(cliente.id.ToString());
                        item.SubItems.Add(cliente.Nombre);
                        item.SubItems.Add(cliente.AP);
                        item.SubItems.Add(cliente.AM);
                        item.SubItems.Add(cliente.Correo);
                        item.SubItems.Add(cliente.Celular);
                        item.SubItems.Add(cliente.Nomina.ToString());
                        item.SubItems.Add(cliente.fechaNa.ToShortDateString());

                        LV_Operativos.Items.Add(item);
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

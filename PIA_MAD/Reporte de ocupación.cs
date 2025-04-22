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
    public partial class Reporte_de_ocupación : Form
    {
        public Reporte_de_ocupación()
        {
            InitializeComponent();
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
    }
}

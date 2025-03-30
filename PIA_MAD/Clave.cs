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
    public partial class Ini_Clave : Form
    {
        public Ini_Clave()
        {
            InitializeComponent();
        }

        private void BT_IniClave_Click(object sender, EventArgs e)
        {
            string Clave = TB_ClaveIni.Text;
            string mainclave = "2050506";

            if (mainclave == Clave)
            {
                Registro registro = new Registro();
                registro.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("La clave que ingresada es incorrecta");
            }

        }
    }
}

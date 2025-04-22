using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PIA_MAD
{
    public partial class Registro_de_clientes : Form
    {
        public Registro_de_clientes()
        {
            InitializeComponent();
            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuSuperior());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanas.VentanaClientes = null;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void sadsddToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkInToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NombreC = TB_RegNomC.Text;
            string APc = TB_regAPc.Text;
            string AMc = TB_regAMc.Text;
            string PaisC = TB_RegPaisC.Text;
            string EstC = TB_RegEstC.Text;
            string CiudadC = TB_RegCiuClie.Text;
            string CorreoC = TB_RegCorreoC.Text;
            string TelC = TB_RegTelC.Text;
            string CelC= TB_RegCelC.Text;
            string RFCc = TB_RegRFCCli.Text;
            DateTime FechNaC = DTP_FechNacC.Value;


            using (var context = new ApplicationDbContext())
            {
                var Us = new Usuario
                {
                    Nombre = NombreC,
                    AP = APc,
                    AM = AMc,
                    Pais= PaisC, 
                    Ciudad= CiudadC, 
                    Estado= EstC,
                    Correo = CorreoC,
                    Telefono = TelC,
                    Celular = CelC,
                    RFC = RFCc,
                    fechaNa = FechNaC
                    
                };

                context.Usuarios.Add(Us);
                context.SaveChanges();

                Debug.WriteLine("Cliente agregado correctamente.");
            }

        }

        private void Registro_de_clientes_Load(object sender, EventArgs e)
        {

        }
    }
}

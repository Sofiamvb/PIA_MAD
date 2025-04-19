using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class MenuSuperior : UserControl
    {

        private Form RegistroCli;
       
        public MenuSuperior(Form RegistroCliente = null)
        {
            InitializeComponent();

            RegistroCli = RegistroCliente;
        }

        private void registroDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form C in Application.OpenForms)
            {
                if (C is Registro_de_clientes)
                {
                    C.Focus(); 
                    return;
                }
            }


            Registro_de_clientes VregC = new Registro_de_clientes();
            VregC.Show();
            RegistroCli.Hide();
            this.Hide();


        }

        private void Menu_VModCli_Click(object sender, EventArgs e)
        {
            //Registro_de_clientes MenuCli = new Registro_de_clientes();
            //MenuCli.Show();
        }

        private void Menu_VReservacion_Click(object sender, EventArgs e)
        {
            foreach (Form R in Application.OpenForms)
            {
                if (R is Reservaciones)
                {
                    R.Focus();
                    
                    return;
                }
            }

            Reservaciones VRv = new Reservaciones();
            VRv.Show();
            RegistroCli.Hide();
            this.Hide();



        }

        private void Menu_VCheckIn_Click(object sender, EventArgs e)
        {
            foreach (Form I in Application.OpenForms)
            {
                if (I is Check_In)
                {
                    I.Focus();
                    return;
                }
            }

            Check_In VCI = new Check_In();
            VCI.Show();
            RegistroCli.Hide();
            this.Hide();


        }

        private void Menu_VCheckOut_Click(object sender, EventArgs e)
        {
            foreach (Form O in Application.OpenForms)
            {
                if (O is Check_Out)
                {
                    O.Focus();
                    return;
                }
            }

            Check_Out VCOut = new Check_Out();
            VCOut.Show();
            RegistroCli.Hide();
            this.Hide();

        }
    }
}

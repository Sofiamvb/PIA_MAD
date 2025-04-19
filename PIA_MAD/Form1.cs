using PIA_MAD.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;

namespace PIA_MAD
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            using (var context = new ApplicationDbContext())
            {
                context.Database.OpenConnection(); 
            }

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ini_Clave Clave = new Ini_Clave();
            Clave.Show();
            this.Hide();
        }

        private void BTN_IngIni_Click(object sender, EventArgs e)
        {


            string Correo = TB_IniCorreo.Text;
            string Contra = TB_IniContra.Text;

            if (RB_IniAdm.Checked)
            {
                using (var DB = new ApplicationDbContext())
                {
                    var admin = DB.Administradores.FromSqlRaw("SELECT * FROM dbo.Administradores WHERE Correo = {0} AND Contra = {1}", Correo, Contra).FirstOrDefault();

                    Debug.WriteLine(admin);

                    if (admin != null)
                    {
                        MessageBox.Show("Has iniciado sesion");

                        Registro_de_hoteles RigHotel = new Registro_de_hoteles();
                        RigHotel.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Intetar de nuevo");
                    }


                }





            }



            if (RB_IniOp.Checked)
            {

                using (var DB = new ApplicationDbContext())
                {
                    var Op = DB.Operativos.FromSqlRaw("SELECT * FROM dbo.Operativos WHERE Correo = {0} AND Contra = {1}", Correo, Contra).FirstOrDefault();

                    Debug.WriteLine(Op);

                    if (Op != null)
                    {
                        MessageBox.Show("Has iniciado sesion");

                        Registro_de_clientes RigCliente = new Registro_de_clientes();
                        RigCliente.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Intetar de nuevo");
                    }


                }






            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {





































































































































































































        }
    }
}

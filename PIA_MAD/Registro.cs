using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            string Nombre = TB_NomRegEmp.Text;
            string AP = TB_APRegEmp.Text;
            string AM = TB_AMRegEmp.Text;
            string Correo = TB_CorreoRegEmp.Text;
            string Tel = TB_TelRegEmp.Text;
            string Cel = TB_CelRegEmp.Text;
            string NumNo = TB_NumNoRegEmp.Text;
            DateTime FechNa = DTP_FecNamEmp.Value;
            string Contra = TB_ContraRegEmp.Text;



            if (RB_AdmRegEmp.Checked)
            {
                using (var context = new ApplicationDbContext())
                {
                    var admin = new Administrador
                    {
                        Nombre = Nombre,
                        AP = AP,
                        AM = AM,
                        Correo = Correo,
                        Telefono = Tel,
                        Celular = Cel,
                        Nomina = NumNo,
                        fechaNa = FechNa,
                        Contra = Contra
                    };

                    context.Administradores.Add(admin);
                    context.SaveChanges();

                    Debug.WriteLine("Administrador agregado correctamente.");
                }
            }
            if (RB_OpRegEmp.Checked)
            {

                using (var context = new ApplicationDbContext())
                {
                    var Op = new Operativos
                    {
                        Nombre = Nombre,
                        AP = AP,
                        AM = AM,
                        Correo = Correo,
                        Telefono = Tel,
                        Celular = Cel,
                        Nomina = NumNo,
                        fechaNa = FechNa,
                        Contra = Contra
                    };

                    context.Operativos.Add(Op);
                    context.SaveChanges();

                    Debug.WriteLine("Operativo agregado correctamente.");
                }

            }

            Form1 IniSesion = new Form1();
            IniSesion.Show();
            this.Hide();

            Debug.WriteLine(Nombre);
        }

        private void TB_NumNoRegEmp_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registro_Load(object sender, EventArgs e)
        {

        }
    }
}

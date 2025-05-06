using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PIA_MAD
{
    public partial class Registro : Form
    {
        private int numeronomina;
        private string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        private string patronContrasenia = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).+$";

        public Registro()
        {
            InitializeComponent();
            DTP_FecNamEmp.MaxDate = DateTime.Today.AddYears(-18);
            TB_NumNoRegEmp.Enabled = false;
            DTP_RegEmpl.ShowUpDown = true;
            DTP_RegEmpl.Enabled = false;
            using (var DB = new ApplicationDbContext()) {
                var ultimoad = DB.Administradores
                    .OrderByDescending(a => a.Nomina)
                    .FirstOrDefault();
                var ultimoop = DB.Operativos
                    .OrderByDescending(a => a.Nomina)
                    .FirstOrDefault();
                if (ultimoad != null && ultimoop == null)
                {
                    numeronomina = ultimoad.Nomina + 1;
                }
                if (ultimoop != null && ultimoad == null)
                {
                    numeronomina = ultimoop.Nomina + 1;
                }
                if (ultimoad != null && ultimoop != null) {
                    if (ultimoad.Nomina > ultimoop.Nomina)
                    {
                        numeronomina = ultimoad.Nomina + 1;
                    }
                    else if(ultimoop.Nomina > ultimoad.Nomina) {
                        numeronomina = ultimoop.Nomina + 1;
                    }
                }
            }
            TB_NumNoRegEmp.Text = numeronomina.ToString();
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

            Correo.ToLower();

            if (
                string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(AP) ||
                string.IsNullOrWhiteSpace(AM) ||
                string.IsNullOrWhiteSpace(Correo) ||
                string.IsNullOrWhiteSpace(Tel) ||
                string.IsNullOrWhiteSpace(Cel) ||
                string.IsNullOrWhiteSpace(NumNo) ||
                string.IsNullOrWhiteSpace(Contra)
            )
            {
                MessageBox.Show("Todos los campos deben estar llenos.");
                return;
            }

            if (!Regex.IsMatch(Nombre, patronNombre))
            {
                MessageBox.Show("El nombre solo puede contener letras y espacios.");
                return;
            }

            if (!Regex.IsMatch(AP, patronNombre)) {
                MessageBox.Show("El apellido paterno solo puede contener letras y espacios");
                return;
            }

            if (!Regex.IsMatch(AM, patronNombre)) {
                MessageBox.Show("El apellido materno solo puede contener letras y espacios");
                return;
            }

            if (!Regex.IsMatch(Correo, patronCorreo)) {
                MessageBox.Show("El dato ingresado debe ser un correo");
                return;
            }

            if (Tel.Length < 8 || Tel.Length > 15)
            {
                MessageBox.Show("El telefono tiene que tener entre 8 y 15 digitos");
                return;
            }

            if (!Regex.IsMatch(Tel, patronTelefono)) {
                MessageBox.Show("El telefono solo puede tener numeros");
                return;
            }

            if (Cel.Length < 10 || Cel.Length > 13) {
                MessageBox.Show("El celular tiene que tener entre 10 y 13 digitos");
                return;
            }

            if (!Regex.IsMatch(Cel, patronTelefono)) {
                MessageBox.Show("El celular solo puede tener numeros");
                return;
            }

            if (!Regex.IsMatch(Contra, patronContrasenia)) {
                MessageBox.Show("La contrasenia debe tener una letra mayuscula, una letra minuscula y un caracter epecial");
                return;
            }

            if (Contra.Length < 8) {
                MessageBox.Show("La contrasenia debe tener al menos 8 caracteres");
                return;
            }


            using (var context = new ApplicationDbContext())
            {
                var ultimoad = context.Administradores
                    .OrderByDescending(a => a.Nomina)
                    .FirstOrDefault();
                var ultimoop = context.Operativos
                    .OrderByDescending(a => a.Nomina)
                    .FirstOrDefault();
                if (ultimoad != null && ultimoop == null)
                {
                    numeronomina = ultimoad.Nomina + 1;
                }
                if (ultimoop != null && ultimoad == null)
                {
                    numeronomina = ultimoop.Nomina + 1;
                }
                if (ultimoad != null && ultimoop != null)
                {
                    if (ultimoad.Nomina > ultimoop.Nomina)
                    {
                        numeronomina = ultimoad.Nomina + 1;
                    }
                    else if (ultimoop.Nomina > ultimoad.Nomina)
                    {
                        numeronomina = ultimoop.Nomina + 1;
                    }
                }
                var admin = new Administrador
                {
                    Nombre = Nombre,
                    AP = AP,
                    AM = AM,
                    Correo = Correo,
                    Telefono = Tel,
                    Celular = Cel,
                    Nomina = numeronomina,
                    fechaNa = FechNa,
                    Contra = Contra,
                    FechaRegistro = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                };

                context.Administradores.Add(admin);
                context.SaveChanges();

                Debug.WriteLine("Administrador agregado correctamente.");
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

        private void RB_OpRegEmp_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore;
using PIA_MAD.Clases;
using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD
{
    public partial class InformacionOperativo : Form
    {
        private int numeronomina;
        private string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        private string patronContrasenia = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).+$";
        Empleado empleado = Empleado.ObtenerInstancia();
        private int operativoId;
        public InformacionOperativo(Operativos operativo)
        {
            InitializeComponent();
            this.operativoId = operativo.id;
            TB_NomRegEmp.Text = operativo.Nombre;
            TB_APRegEmp.Text = operativo.AP;
            TB_AMRegEmp.Text = operativo.AM;
            TB_CelRegEmp.Text = operativo.Celular;
            TB_TelRegEmp.Text = operativo.Telefono;
            TB_CorreoRegEmp.Text = operativo.Correo;
            TB_NumNoRegEmp.Text = operativo.Nomina.ToString();
            TB_NumNoRegEmp.Enabled = false;
            DTP_FecNamEmp.Value = operativo.fechaNa;
            TB_ContraRegEmp.Text = operativo.Contra;
        }

        private void InformacionOperativo_Load(object sender, EventArgs e)
        {

        }

        private void BTN_RegEmp_Click(object sender, EventArgs e)
        {
            string Nombre = TB_NomRegEmp.Text;
            string AP = TB_APRegEmp.Text;
            string AM = TB_AMRegEmp.Text;
            string Correo = TB_CorreoRegEmp.Text;
            string Tel = TB_TelRegEmp.Text;
            string Cel = TB_CelRegEmp.Text;
            DateTime FechNa = DTP_FecNamEmp.Value;
            string Contra = TB_ContraRegEmp.Text;

            if (
                string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(AP) ||
                string.IsNullOrWhiteSpace(AM) ||
                string.IsNullOrWhiteSpace(Correo) ||
                string.IsNullOrWhiteSpace(Tel) ||
                string.IsNullOrWhiteSpace(Cel) ||
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

            if (!Regex.IsMatch(AP, patronNombre))
            {
                MessageBox.Show("El apellido paterno solo puede contener letras y espacios");
                return;
            }

            if (!Regex.IsMatch(AM, patronNombre))
            {
                MessageBox.Show("El apellido materno solo puede contener letras y espacios");
                return;
            }

            if (!Regex.IsMatch(Correo, patronCorreo))
            {
                MessageBox.Show("El dato ingresado debe ser un correo");
                return;
            }

            if (Tel.Length < 8 || Tel.Length > 15)
            {
                MessageBox.Show("El telefono tiene que tener entre 8 y 15 digitos");
                return;
            }

            if (!Regex.IsMatch(Tel, patronTelefono))
            {
                MessageBox.Show("El telefono solo puede tener numeros");
                return;
            }

            if (Cel.Length < 10 || Cel.Length > 13)
            {
                MessageBox.Show("El celular tiene que tener entre 10 y 13 digitos");
                return;
            }

            if (!Regex.IsMatch(Cel, patronTelefono))
            {
                MessageBox.Show("El celular solo puede tener numeros");
                return;
            }

            if (!Regex.IsMatch(Contra, patronContrasenia))
            {
                MessageBox.Show("La contrasenia debe tener una letra mayuscula, una letra minuscula y un caracter epecial");
                return;
            }

            if (Contra.Length < 8)
            {
                MessageBox.Show("La contrasenia debe tener al menos 8 caracteres");
                return;
            }
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    int adminId = empleado.GetId();

                    bool yaFueUsada = context.RegistroContra.Any(rc =>
                    rc.OperativoId == operativoId &&
                    rc.ContraPasada == Contra);

                    if (yaFueUsada)
                    {
                        MessageBox.Show("Esta contraseña ya fue utilizada anteriormente. Usa una nueva.");
                        return;
                    }

                    context.Database.ExecuteSqlRaw(@"
                    UPDATE Operativos
                    SET
                        Nombre = {0},
                        AP = {1},
                        AM = {2},
                        Correo = {3},
                        Telefono = {4},
                        Celular = {5},
                        fechaNa = {6},
                        Contra = {7},
                        FechaModificacion = {8},
                        ModificadorAdministradorId = {9}
                    WHERE id = {10}",
                        Nombre, AP, AM, Correo, Tel, Cel,
                        FechNa, Contra, DateTime.Now, adminId, adminId
                    );

                    context.Database.ExecuteSqlRaw(@"
                    INSERT INTO RegistroContra (OperativoId, ContraPasada)
                    VALUES ({0}, {1})", operativoId, Contra);

                    MessageBox.Show("Administrador actualizado y contraseña registrada.");
                    this.Hide();
                    var nuevoFormulario = new Registro_de_hoteles();
                    nuevoFormulario.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error: {ex.Message}");
                return;
            }
        }
    }
}

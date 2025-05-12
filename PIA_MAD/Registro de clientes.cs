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
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using PIA_MAD.Clases;

namespace PIA_MAD
{
    public partial class Registro_de_clientes : Form
    {
        private string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        private string patronRFC = @"^[A-Za-z]{4}[0-9]{6}[A-Za-z0-9]{3}$";
        private string patronContrasenia = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).+$";
        Empleado empleado = Empleado.ObtenerInstancia();
        public Registro_de_clientes()
        {
            InitializeComponent();
            DTP_FechNacC.MaxDate = DateTime.Today.AddYears(-18);
            DTP_RegClientes.ShowUpDown = true;
            DTP_RegClientes.Enabled = false;
            string[] opEstadoCivil = { "Soltero", "Casado", "Viudo" };
            CB_RegEstCivilC.Items.AddRange(opEstadoCivil);
            if (CB_RegEstCivilC.Items.Count > 0)
                CB_RegEstCivilC.SelectedIndex = 0;
            CB_CFDI.Items.AddRange(new object[] {
                "G01 - Adquisición de mercancías",
                "G02 - Devoluciones, descuentos o bonificaciones",
                "G03 - Gastos en general",
                "I01 - Construcciones",
                "I02 - Mobiliario y equipo de oficina por inversiones",
                "I03 - Equipo de transporte",
                "I04 - Equipo de cómputo y accesorios",
                "I05 - Dados, troqueles, moldes, matrices y herramental",
                "I06 - Comunicaciones telefónicas",
                "I07 - Comunicaciones satelitales",
                "I08 - Otra maquinaria y equipo",
                "D01 - Honorarios médicos, dentales y gastos hospitalarios",
                "D02 - Gastos médicos por incapacidad o discapacidad",
                "D03 - Gastos funerales",
                "D04 - Donativos",
                "D05 - Intereses reales efectivamente pagados por créditos hipotecarios",
                "D06 - Aportaciones voluntarias al SAR",
                "D07 - Primas por seguros de gastos médicos",
                "D08 - Gastos de transportación escolar obligatoria",
                "D09 - Depósitos en cuentas para el ahorro, primas que tengan como base planes de pensiones",
                "D10 - Pagos por servicios educativos (colegiaturas)",
                "S01 - Sin efectos fiscales",
                "CP01 - Pagos"
            });
            if (CB_CFDI.Items.Count > 0)
                CB_CFDI.SelectedIndex = 0;
            CB_RegimenFiscal.Items.AddRange(new object[] {
                "601 - General de Ley Personas Morales",
                "603 - Personas Morales con Fines no Lucrativos",
                "605 - Sueldos y Salarios e Ingresos Asimilados a Salarios",
                "606 - Arrendamiento",
                "607 - Régimen de Enajenación o Adquisición de Bienes",
                "608 - Demás ingresos",
                "609 - Consolidación",
                "610 - Residentes en el extranjero sin establecimiento permanente en México",
                "611 - Ingresos por Dividendos (socios y accionistas)",
                "612 - Personas Físicas con Actividades Empresariales y Profesionales",
                "614 - Ingresos por intereses",
                "615 - Régimen de los ingresos por obtención de premios",
                "616 - Sin obligaciones fiscales",
                "620 - Sociedades Cooperativas de Producción que optan por diferir sus ingresos",
                "621 - Incorporación Fiscal",
                "622 - Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras",
                "623 - Opcional para Grupos de Sociedades",
                "624 - Coordinados",
                "625 - Régimen de las Actividades Empresariales con ingresos a través de Plataformas Tecnológicas",
                "626 - Régimen Simplificado de Confianza",
                "628 - Hidrocarburos",
                "629 - De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales",
                "630 - Enajenación de acciones en bolsa de valores",
            });
            if (CB_RegimenFiscal.Items.Count > 0)
                CB_RegimenFiscal.SelectedIndex = 0;
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
            string CorreoC = TB_RegCorreoC.Text.ToLower();
            string TelC = TB_RegTelC.Text;
            string CelC = TB_RegCelC.Text;
            DateTime FechNaC = DTP_FechNacC.Value;
            string Domicilio = TBT_Domicilio.Text;
            string Codigopostal = TBT_Codigopostal.Text;
            string RFCc = TB_RegRFCCli.Text.ToUpper();
            string Cfdi = CB_CFDI.SelectedItem.ToString();
            string Regimenfiscal = CB_RegimenFiscal.SelectedItem.ToString();
            string EstCivil = CB_RegEstCivilC.SelectedItem.ToString();
            if (
                 string.IsNullOrWhiteSpace(NombreC) ||
                 string.IsNullOrWhiteSpace(APc) ||
                 string.IsNullOrWhiteSpace(AMc) ||
                 string.IsNullOrWhiteSpace(PaisC) ||
                 string.IsNullOrWhiteSpace(EstC) ||
                 string.IsNullOrWhiteSpace(CiudadC) ||
                 string.IsNullOrWhiteSpace(CorreoC) ||
                 string.IsNullOrWhiteSpace(TelC) ||
                 string.IsNullOrWhiteSpace(CelC) ||
                 string.IsNullOrWhiteSpace(Domicilio) ||
                 string.IsNullOrWhiteSpace(Codigopostal) ||
                 string.IsNullOrWhiteSpace(RFCc) ||
                 EstCivil == null
             ) {
                MessageBox.Show("Todos los elementos deben tener un valor");
                return;
            }

            if (!Regex.IsMatch(NombreC, patronNombre)) {
                MessageBox.Show("El nombre debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(APc, patronNombre)) {
                MessageBox.Show("El apellido paterno debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(AMc, patronNombre)){
                MessageBox.Show("El apellido materno debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(PaisC, patronNombre)) {
                MessageBox.Show("El pais debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(EstC, patronNombre))
            {
                MessageBox.Show("El estado debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(CiudadC, patronNombre)) 
            {
                MessageBox.Show("La ciudad debe contener solo letras y espacios");
                return;
            }

            if(!Regex.IsMatch(CorreoC, patronCorreo))
            {
                MessageBox.Show("El correo debe tener el formato del correo");
                return;
            }

            if (!Regex.IsMatch(TelC, patronTelefono))
            {
                MessageBox.Show("El telefono debe contener solo numeros");
                return;
            }

            if(!Regex.IsMatch(CelC, patronTelefono))
            {
                MessageBox.Show("El celular debe contener solo numeros");
                return;
            }

            if (RFCc.Length != 13) 
            {
                MessageBox.Show("El RFC debe tener 13 de longitud");
                return;
            }

            if(!Regex.IsMatch(Codigopostal, patronTelefono))
            {
                MessageBox.Show("El codigo postal debe tener solo numeros");
                return;
            }

            if (!Regex.IsMatch(RFCc, patronRFC))
            {
                MessageBox.Show("El formato del RFC es incorrecto");
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var Us = new Usuario
                    {
                        CreadorAdministradorId = empleado.GetId(),
                        ModificadorAdministradorId = empleado.GetId(),
                        Nombre = NombreC,
                        AP = APc,
                        AM = AMc,
                        Correo = CorreoC,
                        Telefono = TelC,
                        Celular = CelC,
                        RFC = RFCc,
                        Cfdi = Cfdi,
                        RegimenFiscal = Regimenfiscal,
                        fechaNa = FechNaC,
                        EstadoCivil = EstCivil,
                        Pais = PaisC,
                        Ciudad = CiudadC,
                        Estado = EstC,
                        Domicilio = Domicilio,
                        Codigopostal = Codigopostal,
                        FechaRegistro = DateTime.Now,
                        FechaModifacion = DateTime.Now,
                    };

                    context.Usuarios.Add(Us);
                    context.SaveChanges();

                    MessageBox.Show($"El usuario: {empleado.GetNombreCompleto()} con Rol: {empleado.GetRol()} registro un nuevo cliente.");


                    this.Hide();
                    var nuevoFormulario = new Registro_de_clientes();
                    nuevoFormulario.Show();
                    this.Close();
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return;
            }

        }

        private void Registro_de_clientes_Load(object sender, EventArgs e)
        {
            CB_CFDI.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_RegimenFiscal.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}

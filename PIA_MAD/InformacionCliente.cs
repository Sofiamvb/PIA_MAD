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
    public partial class InformacionCliente : Form
    {
        private string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        private string patronNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ\s]+$";
        private string patronTelefono = @"^\d+$";
        private string patronRFC = @"^[A-Za-z]{4}[0-9]{6}[A-Za-z0-9]{3}$";
        private int clienteId;
        Empleado empleado = Empleado.ObtenerInstancia();
        public InformacionCliente(Usuario cliente)
        {
            InitializeComponent();
            this.clienteId = cliente.id;
            DTP_FechNacC.MaxDate = DateTime.Today.AddYears(-18);
            DTP_RegClientes.ShowUpDown = true;
            DTP_RegClientes.Enabled = false;

            TB_RegNomC.Text = cliente.Nombre;
            TB_regAPc.Text = cliente.AP;
            TB_regAMc.Text = cliente.AM;
            TB_RegPaisC.Text = cliente.Pais;
            TB_RegEstC.Text = cliente.Estado;
            TB_RegCiuClie.Text = cliente.Ciudad;
            TB_RegCorreoC.Text = cliente.Correo;
            TB_RegTelC.Text = cliente.Telefono;
            TB_RegCelC.Text = cliente.Celular;

            string[] opEstadoCivil = { "Soltero", "Casado", "Viudo" };
            CB_RegEstCivilC.Items.AddRange(opEstadoCivil);
            int index = Array.IndexOf(opEstadoCivil, cliente.EstadoCivil);
            if (index >= 0)
                CB_RegEstCivilC.SelectedIndex = index;
            else
                CB_RegEstCivilC.SelectedIndex = 0;

            DTP_FechNacC.Value = cliente.fechaNa;

            TBT_Domicilio.Text = cliente.Domicilio;

            TBT_Codigopostal.Text = cliente.Codigopostal;

            TB_RegRFCCli.Text = cliente.RFC;

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
            string cfdiSeleccionado = cliente.Cfdi;
            int cfdiIndex = -1;
            for (int i = 0; i < CB_CFDI.Items.Count; i++)
            {
                if (CB_CFDI.Items[i].ToString() == cfdiSeleccionado)
                {
                    cfdiIndex = i;
                    break;
                }
            }
            CB_CFDI.SelectedIndex = cfdiIndex >= 0 ? cfdiIndex : 0;

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
            string regimenSeleccionado = cliente.RegimenFiscal;
            int regimenIndex = -1;
            for (int i = 0; i < CB_RegimenFiscal.Items.Count; i++)
            {
                if (CB_RegimenFiscal.Items[i].ToString() == regimenSeleccionado)
                {
                    regimenIndex = i;
                    break;
                }
            }
            CB_RegimenFiscal.SelectedIndex = regimenIndex >= 0 ? regimenIndex : 0;

            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuSuperior());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanas.VentanaClientes = null;
        }

        private void InformacionCliente_Load(object sender, EventArgs e)
        {
            CB_CFDI.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_RegimenFiscal.DropDownStyle = ComboBoxStyle.DropDownList;
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
             )
            {
                MessageBox.Show("Todos los elementos deben tener un valor");
                return;
            }

            if (!Regex.IsMatch(NombreC, patronNombre))
            {
                MessageBox.Show("El nombre debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(APc, patronNombre))
            {
                MessageBox.Show("El apellido paterno debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(AMc, patronNombre))
            {
                MessageBox.Show("El apellido materno debe contener solo letras y espacios");
                return;
            }

            if (!Regex.IsMatch(PaisC, patronNombre))
            {
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

            if (!Regex.IsMatch(CorreoC, patronCorreo))
            {
                MessageBox.Show("El correo debe tener el formato del correo");
                return;
            }

            if (!Regex.IsMatch(TelC, patronTelefono))
            {
                MessageBox.Show("El telefono debe contener solo numeros");
                return;
            }

            if (!Regex.IsMatch(CelC, patronTelefono))
            {
                MessageBox.Show("El celular debe contener solo numeros");
                return;
            }

            if (RFCc.Length != 13)
            {
                MessageBox.Show("El RFC debe tener 13 de longitud");
                return;
            }

            if (!Regex.IsMatch(Codigopostal, patronTelefono))
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
                    context.Database.ExecuteSqlRaw(@"
                        UPDATE Usuarios
                        SET 
                            ModificadorAdministradorId = {0},
                            Nombre = {1},
                            AP = {2},
                            AM = {3},
                            Correo = {4},
                            Telefono = {5},
                            Celular = {6},
                            RFC = {7},
                            Cfdi = {8},
                            RegimenFiscal = {9},
                            fechaNa = {10},
                            EstadoCivil = {11},
                            Pais = {12},
                            Ciudad = {13},
                            Estado = {14},
                            Domicilio = {15},
                            Codigopostal = {16},
                            FechaModifacion = {17}
                        WHERE id = {18}",
                        empleado.GetId(),      
                        NombreC,            
                        APc,                  
                        AMc,                    
                        CorreoC,              
                        TelC,                  
                        CelC,                   
                        RFCc,                  
                        Cfdi,                   
                        Regimenfiscal,          
                        FechNaC,               
                        EstCivil,               
                        PaisC,                  
                        CiudadC,               
                        EstC,                  
                        Domicilio,             
                        Codigopostal,           
                        DateTime.Now,         
                        clienteId               
                    );

                    MessageBox.Show($"El usuario: {empleado.GetNombreCompleto()} con Rol: {empleado.GetRol()} actualizó un cliente.");

                    this.Hide();
                    var nuevoFormulario = new Registro_de_clientes();
                    nuevoFormulario.Show();
                    this.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Hubo un error: {ex.Message}");
                return;
            }
        }
    }
}

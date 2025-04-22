using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace PIA_MAD
{

    public partial class Registro_de_habitaciones : Form
    {
        private bool _comboBoxCargado = false;
        private int cantidaddisponiblehab;
        public Registro_de_habitaciones()
        {
            InitializeComponent();
            using (var context = new ApplicationDbContext())
            {
                var Hoteles = context.Hoteles.FromSqlRaw("SELECT * FROM dbo.Hoteles").ToList();

                CB_RegHotelDHb.DataSource = Hoteles;
                CB_RegHotelDHb.DisplayMember = "Nombre";
                CB_RegHotelDHb.ValueMember = "id";
                if (Hoteles.Count > 0)
                {
                    var primerHotel = Hoteles[0];
                    int ocupadas = context.Habitaciones.Count(h => h.HotelId == primerHotel.id);
                    cantidaddisponiblehab = primerHotel.cantHab - ocupadas;

                    LBL_CantHabDisponible.Text = cantidaddisponiblehab.ToString();
                    CB_RegHotelDHb.SelectedIndex = 0;
                }
            }
            _comboBoxCargado = true;
            string[] opNivelHab = { "Estandar", "Deluxe", "Ejecutiva", "Suite" };
            CB_regNvHab.Items.AddRange(opNivelHab);

            string[] TCama = { "Individual", "Matrimonial", "Sofá cama", "Queen", "King" };
            CB_TipoCHab.Items.AddRange(TCama);

            _comboBoxCargado = true;

            if (CB_RegHotelDHb.Items.Count > 0)
                CB_RegHotelDHb.SelectedIndex = 0;

            if (CB_regNvHab.Items.Count > 0)
                CB_regNvHab.SelectedIndex = 0;

            if (CB_TipoCHab.Items.Count > 0)
                CB_TipoCHab.SelectedIndex = 0;

            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaHoteles = null;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                CB_RegHotelDHb.SelectedValue == null ||
                CB_regNvHab.SelectedItem == null ||
                CB_TipoCHab.SelectedItem == null ||
                string.IsNullOrWhiteSpace(TB_RegCantHhb.Text) ||
                TB_RegCantHhb.Text == "0" ||
                string.IsNullOrWhiteSpace(TB_RegNumCHb.Text) ||
                string.IsNullOrWhiteSpace(TB_RegPNHb.Text) ||
                string.IsNullOrWhiteSpace(TB_RegCapHb.Text) ||
                string.IsNullOrWhiteSpace(TB_RegVistaHb.Text) ||
                string.IsNullOrWhiteSpace(TB_RegAmeHb.Text) ||
                string.IsNullOrWhiteSpace(TB_RegCaractHb.Text)
            ) {
                MessageBox.Show("Todos los elementos deben tener un valor");
                return;
            }
            int HotelDHb = (int)CB_RegHotelDHb.SelectedValue;
            string NvHab = CB_regNvHab.SelectedItem.ToString();
            string TipoC = CB_TipoCHab.SelectedItem.ToString();
            string CantHabHb = TB_RegCantHhb.Text;
            string NumCHb = TB_RegNumCHb.Text;
            string PrecioNHb = TB_RegPNHb.Text;
            string CapHb = TB_RegCapHb.Text;
            string VistaHb = TB_RegVistaHb.Text;
            string AmeHb = TB_RegAmeHb.Text;
            string CaractHb = TB_RegCaractHb.Text;
            DateTime FechNaHb = DTP_RegHab.Value;
            try
            {

                int CantHab = Int32.Parse(CantHabHb);
                int NoCamas = Int32.Parse(NumCHb);
                int PrecioNoche = Int32.Parse(PrecioNHb);
                int Capacidad = Int32.Parse(CapHb);

                using (var context = new ApplicationDbContext())
                {
                    for(int i = 0; i <= CantHab; i++)
                    {
                        var Hab = new Habitaciones
                        {
                            fechNaHab = FechNaHb,
                            HotelId = HotelDHb,
                            NoCamas = NoCamas,
                            tipoCama = TipoC,
                            PrecioNoche = PrecioNoche,
                            Capacidad = Capacidad,
                            nivelHab = NvHab,
                            Vista = VistaHb,
                            Amenidades = AmeHb,
                            caracteristicas = CaractHb
                        };

                        context.Habitaciones.Add(Hab);
                    }
                    context.SaveChanges();

                    MessageBox.Show("Habitaciones guardadas!");
                }


            }
            catch (FormatException error)
            {
                Debug.WriteLine(error.Message);
            }
            //Traer radiobutton y ints


        }

        private void CB_RegHotelDHb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_comboBoxCargado) return;

            var hotelseleccionado = CB_RegHotelDHb.SelectedItem as Hoteles;
            if (hotelseleccionado != null)
            {
                using (var DB = new ApplicationDbContext())
                {
                    int cantidadocupada = DB.Habitaciones.Where(h => h.HotelId == hotelseleccionado.id).Count();
                    cantidaddisponiblehab = hotelseleccionado.cantHab - cantidadocupada;
                    Debug.WriteLine(cantidaddisponiblehab);
                    LBL_CantHabDisponible.Text = cantidaddisponiblehab.ToString();
                }
            }
        }

        private void Registro_de_habitaciones_Load(object sender, EventArgs e)
        {

        }

        private void TB_RegCantHhb_TextChanged(object sender, EventArgs e)
        {
            if (cantidaddisponiblehab <= 0)
                return;
            try
            {
                string CantHabHb = TB_RegCantHhb.Text;
                if (string.IsNullOrWhiteSpace(CantHabHb))
                {
                    CantHabHb = "0";
                }

                int canthab = Int32.Parse(CantHabHb);
                int result = cantidaddisponiblehab - canthab;
                Debug.WriteLine(result);

                if (result < 0)
                {
                    Debug.WriteLine($"Dentro del if. Resultado: {result}");
                    MessageBox.Show("Número no válido, tiene que ser menor o igual a la disponibilidad.");
                    TB_RegCantHhb.Text = "0";
                }
            }
            catch (FormatException error)
            {
                MessageBox.Show("Formato no válido, tiene que ser un número", error.Message);
                TB_RegCantHhb.Text = "0";
            }
        }

    }
}

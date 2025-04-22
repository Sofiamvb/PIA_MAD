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


namespace PIA_MAD
{
    public partial class Registro_de_habitaciones : Form
    {
        public Registro_de_habitaciones()
        {
            InitializeComponent();
            using (var context = new ApplicationDbContext())
            {
                var Hotel = context.Hoteles.FromSqlRaw("SELECT Nombre,id FROM dbo.Hoteles").ToList();

                CB_RegHotelDHb.DataSource = Hotel;
                CB_RegHotelDHb.DisplayMember = "Nombre";
                CB_RegHotelDHb.ValueMember = "id";

            }
            string[] opNivelHab = { "Estandar", "Deluxe", "Ejecutiva", "Suite" };
            CB_regNvHab.Items.AddRange(opNivelHab);

            string[] TCama = { "Individual", "Matrimonial", "Sofá cama", "Queen", "King" };
            CB_TipoCHab.Items.AddRange(TCama);

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
                    var Hab = new Habitaciones
                    {
                        HotelId = HotelDHb,
                        nivelHab = NvHab,
                        CantHab = CantHab,
                        NoCamas = NoCamas,
                        PrecioNoche = PrecioNoche,
                        Capacidad = Capacidad,
                        caracteristicas = CaractHb,
                        Amenidades = AmeHb,
                        fechNaHab = FechNaHb

                    };

                    context.Habitaciones.Add(Hab);
                    context.SaveChanges();

                    Debug.WriteLine("Habitacion agregada correctamente.");
                }


            }
            catch(FormatException error)
            {
                Debug.WriteLine(error.Message);
            }
            //Traer radiobutton y ints

           
        }

        private void CB_RegHotelDHb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

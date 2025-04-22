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
using Microsoft.EntityFrameworkCore;


namespace PIA_MAD
{
    public partial class Registro_de_hoteles : Form
    {
        public Registro_de_hoteles()
        {
            InitializeComponent();
            this.FormClosed += FormClosedHandler;
            this.Controls.Add(new MenuAdministrador());
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            GestorVentanasAdm.VentanaHoteles = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NombreH = TB_RegNomH.Text;
            string PaisH = TB_RegPaisH.Text;
            string NumPiso = TB_RegNumPH.Text;
            string CantHabH = TB_RegChabH.Text;
            string CantPiscinaH = TB_RegCantPisH.Text;
            string EstH = TB_RegEstH.Text;
            string CiudadH = TB_RegCuH.Text;
            string DomH = TB_RegDomH.Text;
            string NumP = TB_RegNumPH.Text;
            string CaractH = TB_RegCaracH.Text;
            string AmeH = TB_RegAmeH.Text;
            string CanHab = TB_RegChabH.Text;
            string ServAd = TB_RegServAdH.Text;
            string CantPiscinas = TB_RegCantPisH.Text;
            DateTime FechNaH = DTP_RegHotel.Value;
            //Traer 
            try
            {
                int PisoH = Int32.Parse(NumPiso);
                int CantHabitacion = Int32.Parse(CantHabH);
                int CantPiscina = Int32.Parse(CantPiscinaH);

                using (var context = new ApplicationDbContext())
                {
                    var Hotel = new Hoteles
                    {
                        Nombre = NombreH,
                        Pisos = PisoH,
                        cantHab = CantHabitacion,
                        CantPiscina = CantPiscina,
                        pais = PaisH,
                        estado = EstH,
                        ciudad = CiudadH,
                        domicilio = DomH,
                        caracteristicas = CaractH,
                        amenidades = AmeH,
                        serviciosAd = ServAd,
                        FechNaH = FechNaH

                    };

                    context.Hoteles.Add(Hotel);
                    context.SaveChanges();

                    Debug.WriteLine("Hotel agregado correctamente.");
                }

            }
            catch (FormatException error)
            {
                MessageBox.Show("Solo números son válidos", error.Message);
            }


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

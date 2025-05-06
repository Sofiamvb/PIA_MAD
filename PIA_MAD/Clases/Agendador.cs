using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace PIA_MAD.Clases
{
    public class Agendador
    {
        private Timer _reloj;
        private bool _yaSeEjecutóHoy = false;

        public Agendador()
        {
            _reloj = new Timer(60 * 1000); // Ejecutar cada minuto
            _reloj.Elapsed += VerificarHora;
            _reloj.Start();
        }

        private void VerificarHora(object sender, ElapsedEventArgs e)
        {
            var ahora = DateTime.Now;

            if (ahora.Hour == 0 && ahora.Minute == 0 && !_yaSeEjecutóHoy)
            {
                using (var db = new ApplicationDbContext())
                {
                    var servicio = new ReservacionService(db);
                    servicio.CancelarReservacionesNoCheckIn();
                }

                _yaSeEjecutóHoy = true;
            }

            // Reiniciar el flag al final del día (justo antes de medianoche)
            if (ahora.Hour == 23 && ahora.Minute == 59)
            {
                _yaSeEjecutóHoy = false;
            }
        }

    }
}

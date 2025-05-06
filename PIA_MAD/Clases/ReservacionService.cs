using Microsoft.EntityFrameworkCore;
using PIA_MAD.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD.Clases
{
    public class ReservacionService
    {
        private readonly ApplicationDbContext _context;

        public ReservacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CancelarReservacionManual(Guid codigoReserva)
        {
            var reservacion = _context.Reservaciones
                .Include(r => r.HabitacionReservada)
                .FirstOrDefault(r => r.CodigoReserva == codigoReserva);

            if (reservacion == null)
            {
                MessageBox.Show("No se encontró una reservación con ese código.");
                return false;
            }

            TimeSpan diferencia = reservacion.FechaEnt.Date - DateTime.Now.Date;

            if (diferencia.TotalDays < 3)
            {
                MessageBox.Show("La cancelación debe hacerse con al menos 3 días de anticipación.");
                return false;
            }

            if (reservacion != null)
            {
                // Guardar en tabla Cancelaciones
                var cancelacion = new Cancelaciones
                {
                    TipoCancelacion = "Manual",
                    ClienteId = reservacion.ClienteId,
                    HotelId = reservacion.HotelId,
                    CantPersonas = reservacion.CantPersonas,
                    AnticipoADevolver = reservacion.Anticipo, // o aplica lógica de penalización
                    CodigoReserva = reservacion.CodigoReserva,
                    FechaEnt = reservacion.FechaEnt,
                    FechaSal = reservacion.FechaSal,
                    FechaReserva = reservacion.FechaReserva,
                    FechaCancelacion = DateTime.Now,
                    CheckInRealizado = reservacion.CheckInRealizado,
                    HabitacionesReservadas = reservacion.HabitacionReservada
                };

                _context.Cancelaciones.Add(cancelacion);

                // Eliminar
                _context.HabitacionReservada.RemoveRange(reservacion.HabitacionReservada);
                _context.Reservaciones.Remove(reservacion);

                _context.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("No se encontró una reservación con ese código.");
                return false;
            }
        }


        public void CancelarReservacionesNoCheckIn()
        {
            DateTime fechaLimite = DateTime.Today;

            var reservacionesExpiradas = _context.Reservaciones
                .Include(r => r.HabitacionReservada)
                .Where(r => !r.CheckInRealizado && r.FechaEnt < fechaLimite)
                .ToList();


            foreach (var reservacion in reservacionesExpiradas)
            {
                // Crear y guardar la cancelación
                var cancelacion = new Cancelaciones
                {
                    TipoCancelacion = "Inasistencia",
                    ClienteId = reservacion.ClienteId,
                    HotelId = reservacion.HotelId,
                    CantPersonas = reservacion.CantPersonas,
                    AnticipoADevolver = reservacion.Anticipo, 
                    CodigoReserva = reservacion.CodigoReserva,
                    FechaEnt = reservacion.FechaEnt,
                    FechaSal = reservacion.FechaSal,
                    FechaReserva = reservacion.FechaReserva,
                    FechaCancelacion = DateTime.Now,
                    CheckInRealizado = false,
                    HabitacionesReservadas = reservacion.HabitacionReservada
                };

                _context.Cancelaciones.Add(cancelacion);

                // Eliminar habitaciones reservadas y la reservación
                _context.HabitacionReservada.RemoveRange(reservacion.HabitacionReservada);
                _context.Reservaciones.Remove(reservacion);

            }

            _context.SaveChanges();
        }
    }
}

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
        public static int AdministradorSistemaId { get; private set; }

        public ReservacionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool RevisarOCrearUsuarioSistema()
        {
            try
            {
                var admin = _context.Administradores.FromSqlRaw("SELECT * FROM dbo.Administradores WHERE Nomina = 1").FirstOrDefault();
                if (admin != null)
                {
                    AdministradorSistemaId = admin.id;
                    return true;
                }
                var adminSistema = new Administrador
                {
                    Nombre = "System",
                    AP = "Auto",
                    AM = "Process",
                    Correo = "system@pia-mad.local",
                    Telefono = "0000000000",
                    Celular = "0000000000",
                    Nomina = 1,
                    fechaNa = new DateTime(2000, 1, 1),
                    Contra = "system123",
                    FechaRegistro = DateTime.Now,
                    FechaModificacion = DateTime.Now
                };
                _context.Administradores.Add(adminSistema);
                _context.SaveChanges();

                AdministradorSistemaId = adminSistema.id;

                return true;
            } catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al crear el usuario del sistema {ex}");
                return false;
            }
        }

        public bool CancelarReservacionManual(Guid codigoReserva, int administradorid)
        {
            try
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
                    var cancelacion = new Cancelaciones
                    {
                        TipoCancelacion = "Manual",
                        AdministradorId = administradorid,
                        ClienteId = reservacion.ClienteId,
                        HotelId = reservacion.HotelId,
                        CantPersonas = reservacion.CantPersonas,
                        AnticipoADevolver = reservacion.Anticipo,
                        CodigoReserva = reservacion.CodigoReserva,
                        FechaEnt = reservacion.FechaEnt,
                        FechaSal = reservacion.FechaSal,
                        FechaReserva = reservacion.FechaReserva,
                        FechaCancelacion = DateTime.Now,
                        CheckInRealizado = reservacion.CheckInRealizado,
                    };

                    _context.Cancelaciones.Add(cancelacion);
                    _context.SaveChanges();

                    var habitacionesCanceladas = reservacion.HabitacionReservada
                        .Select(hr => new HabitacionCancelacion
                        {
                            HabitacionId = hr.HabitacionId,
                            CantidadPersonas = hr.CantidadPersonas,
                            CancelacionId = cancelacion.id
                        }).ToList();

                    _context.HabitacionCancelacion.AddRange(habitacionesCanceladas);

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
            catch (Exception ex) {
                MessageBox.Show($"Oh nooooooo, la politziaaa, algo fallo: {ex}");
                return false;
            }
            
        }


        public void CancelarReservacionesNoCheckIn()
        {
            DateTime fechaLimite = DateTime.Today;
            try
            {
                var reservacionesExpiradas = _context.Reservaciones
                .Include(r => r.HabitacionReservada)
                .Where(r => !r.CheckInRealizado && r.FechaEnt < fechaLimite)
                .ToList();


                foreach (var reservacion in reservacionesExpiradas)
                {
                    var cancelacion = new Cancelaciones
                    {
                        TipoCancelacion = "Inasistencia",
                        AdministradorId = AdministradorSistemaId,
                        ClienteId = reservacion.ClienteId,
                        HotelId = reservacion.HotelId,
                        CantPersonas = reservacion.CantPersonas,
                        AnticipoADevolver = reservacion.Anticipo, 
                        CodigoReserva = reservacion.CodigoReserva,
                        FechaEnt = reservacion.FechaEnt,
                        FechaSal = reservacion.FechaSal,
                        FechaReserva = reservacion.FechaReserva,
                        FechaCancelacion = DateTime.Now,
                        CheckInRealizado = false
                    };

                    _context.Cancelaciones.Add(cancelacion);
                    _context.SaveChanges(); 

                    var habitacionesCanceladas = reservacion.HabitacionReservada
                        .Select(hr => new HabitacionCancelacion
                        {
                            HabitacionId = hr.HabitacionId,
                            CantidadPersonas = hr.CantidadPersonas,
                            CancelacionId = cancelacion.id
                        }).ToList();

                    _context.HabitacionCancelacion.AddRange(habitacionesCanceladas);
                    _context.HabitacionReservada.RemoveRange(reservacion.HabitacionReservada);
                    _context.Reservaciones.Remove(reservacion);

                }
                _context.SaveChanges();
            }
            catch (Exception ex) {
                MessageBox.Show($"Hubo un error al momento de cancelar las reservaciones que no hicieron check in {ex}");            
            }
            
        }
    }
}

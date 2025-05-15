using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PIA_MAD.Clases;
using System.Linq;

namespace PIA_MAD.Modelos
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<Hoteles> Hoteles { get; set; }
        public DbSet<Operativos> Operativos { get; set; }
        public DbSet<RegistroContra> RegistroContra { get; set; }
        public DbSet<ReporteVentas> ReporteVentas { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cancelaciones> Cancelaciones { get; set; }
        public DbSet<HabitacionReservada> HabitacionReservada { get; set; }
        public DbSet<ServicioAdicionalHotel> ServiciosAdicionalesHotel { get; set; }
        public DbSet<CheckOut> CheckOut { get; set; }
        public DbSet<HabitacionCheckout> HabitacionCheckout { get; set; }
        public DbSet<CheckOutServicioAdicional> CheckOutServiciosAdicionales { get; set; }
        public DbSet<VentaAnticipoResultado> VentasYAnticiposView { get; set; }
        public DbSet<HotelListado> HotelesPorUbicacion { get; set; }
        public DbSet<ReporteOcupacion> ReporteOcupacionView { get; set; }
        public DbSet<HabitacionCancelacion> HabitacionCancelacion { get; set; }
        public DbSet<HistorialClienteDTO> HistorialCliente { get; set; }

        // --- Vistas ===
        public DbSet<HotelUbicacionDTO> VistaHotelesUbicacion { get; set; }

        public DbSet<VistaHabitacionesHotelesDTO> VistaHabitacionesHoteles { get; set; }

        public DbSet<UsuarioVistaDTO> VistaUsuariosSimplificada { get; set; }

        public DbSet<OperativoVistaDTO> Vista_Operativos { get; set; }

        public DbSet<UsuarioBasicoDTO> Vista_UsuariosBasica { get; set; }
        public DbSet<ReporteVentasDTO> Vista_VentasYAnticipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioVistaDTO>().HasNoKey().ToView("VistaUsuariosSimplificada");
            modelBuilder.Entity<VistaHabitacionesHotelesDTO>().HasNoKey().ToView("VistaHabitacionesHoteles");
            modelBuilder.Entity<HotelUbicacionDTO>()
                .HasNoKey()
                .ToView("VistaHotelesUbicacion");
            modelBuilder.Entity<OperativoVistaDTO>()
                .HasNoKey()
                .ToView("Vista_Operativos");
            modelBuilder.Entity<UsuarioBasicoDTO>()
                .HasNoKey()
                .ToView("Vista_UsuariosBasica");
            modelBuilder.Entity<ReporteVentasDTO>()
                .HasNoKey()
                .ToView("Vista_VentasYAnticipos");
            modelBuilder.Entity<HistorialClienteDTO>().HasNoKey().ToView(null);
            modelBuilder.Entity<ReporteOcupacion>().HasNoKey().ToView(null);
            // --- Usuarios ---
            modelBuilder.Entity<Usuario>()
               .HasOne(h => h.Creador)
               .WithMany()
               .HasForeignKey(h => h.CreadorAdministradorId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasOne(h => h.Modificador)
                .WithMany()
                .HasForeignKey(h => h.ModificadorAdministradorId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Operativos ---
            modelBuilder.Entity<Operativos>()
               .HasOne(h => h.Creador)
               .WithMany()
               .HasForeignKey(h => h.CreadorAdministradorId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Operativos>()
                .HasOne(h => h.Modificador)
                .WithMany()
                .HasForeignKey(h => h.ModificadorAdministradorId)
                .OnDelete(DeleteBehavior.Restrict);


            // --- Habitaciones ---
            modelBuilder.Entity<Habitaciones>()
                .HasOne(h => h.Creador)
                .WithMany()
                .HasForeignKey(h => h.CreadorAdministradorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Habitaciones>()
                .HasOne(h => h.Modificador)
                .WithMany()
                .HasForeignKey(h => h.ModificadorAdministradorId)
                .OnDelete(DeleteBehavior.Restrict);


            // --- Hoteles ---
            modelBuilder.Entity<Hoteles>()
                .HasOne(h => h.Creador)
                .WithMany()
                .HasForeignKey(h => h.CreadorAdministradorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hoteles>()
                .HasOne(h => h.Modificador)
                .WithMany()
                .HasForeignKey(h => h.ModificadorAdministradorId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- HabitacionReservada ---
            modelBuilder.Entity<HabitacionReservada>()
                .HasOne(hr => hr.Reservacion)
                .WithMany(r => r.HabitacionReservada)
                .HasForeignKey(hr => hr.ReservacionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HabitacionReservada>()
                .HasOne(hr => hr.Habitacion)
                .WithMany()
                .HasForeignKey(hr => hr.HabitacionId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- CheckOut ---
            modelBuilder.Entity<CheckOut>()
                .HasOne(c => c.Operativo)
                .WithMany()
                .HasForeignKey(c => c.OperativoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CheckOut>()
                .HasOne(c => c.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CheckOut>()
                .HasOne(c => c.Hotel)
                .WithMany()
                .HasForeignKey(c => c.HotelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CheckOut>()
                .Property(c => c.Anticipo)
                .HasPrecision(10, 2);

            // --- CheckOutServicioAdicional ---

            modelBuilder.Entity<CheckOutServicioAdicional>()
                .HasOne(csa => csa.CheckOut)
                .WithMany(co => co.ServiciosAdicionales)
                .HasForeignKey(csa => csa.CheckOutId)
                .OnDelete(DeleteBehavior.Cascade);



            // --- HabitacionCheckout---
            modelBuilder.Entity<HabitacionCheckout>()
                .HasOne(hc => hc.CheckOut)
                .WithMany(c => c.HabitacionCheckout)
                .HasForeignKey(hc => hc.CheckOutId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HabitacionCheckout>()
                .HasOne(hc => hc.Habitacion)
                .WithMany()
                .HasForeignKey(hc => hc.HabitacionId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- HabitacionCancelacion ---
            modelBuilder.Entity<HabitacionCancelacion>()
                .HasOne(hc => hc.Habitacion)
                .WithMany()
                .HasForeignKey(hc => hc.HabitacionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HabitacionCancelacion>()
                .HasOne(hc => hc.Cancelacion)
                .WithMany()
                .HasForeignKey(hc => hc.CancelacionId)
                .OnDelete(DeleteBehavior.Cascade);


            // --- Cancelaciones ---
            modelBuilder.Entity<Cancelaciones>()
                .Property(c => c.AnticipoADevolver)
                .HasPrecision(10, 2);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=LAPTOP-2JLT5J0B\\MSSQLSERVER01;Database=CadenaHotelera;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }
        }
    }
}

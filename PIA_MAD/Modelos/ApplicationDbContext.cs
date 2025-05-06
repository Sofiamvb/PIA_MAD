using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HabitacionReservada>()
                .HasOne(hr => hr.Habitacion)
                .WithMany()
                .HasForeignKey(hr => hr.HabitacionId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- Cancelaciones ---
            modelBuilder.Entity<Cancelaciones>()
                .Property(c => c.AnticipoADevolver)
                .HasPrecision(10, 2);

            // --- Opcional: Si quieres que todas las demás relaciones también sean Restrict ---
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
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

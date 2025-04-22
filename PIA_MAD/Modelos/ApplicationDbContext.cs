using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Evitar ruta de cascada múltiple: Reservacion → HabitacionReservada
            modelBuilder.Entity<HabitacionReservada>()
                .HasOne(hr => hr.Reservacion)
                .WithMany(r => r.HabitacionesReservadas)
                .HasForeignKey(hr => hr.ReservacionId)
                .OnDelete(DeleteBehavior.Restrict); // 👈 Esto rompe la cascada

            // (Opcional) También puedes restringir del otro lado si quieres más control
            modelBuilder.Entity<HabitacionReservada>()
                .HasOne(hr => hr.Habitacion)
                .WithMany()
                .HasForeignKey(hr => hr.HabitacionId)
                .OnDelete(DeleteBehavior.Restrict);
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
                Environment.Exit(1); // Cierra la aplicación completamente con código de error
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EB9COQ9;Database=CadenaHotelera;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}

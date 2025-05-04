// Data/DbContextBeachHotel.cs
using Microsoft.EntityFrameworkCore;

namespace ProyectoHotel.Models
{
    public class DbContextBeachHotel : DbContext
    {
        public DbContextBeachHotel(DbContextOptions<DbContextBeachHotel> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Reservacion> Reservas { get; set; }
        public DbSet<Roles> Roles { get; set; }
    }
}

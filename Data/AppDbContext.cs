using Banana.Booking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Banana.Booking.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<SalaDeReuniao> salasDeReuniao { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
                .HasOne(reserva => reserva.SalaDeReuniao)
                .WithMany(sala => sala.Reservas)
                .HasForeignKey(reserva => reserva.SalaDeReuniaoId);

            modelBuilder.Entity<Reserva>()
                .HasIndex(reserva => new {reserva.SalaDeReuniaoId, reserva.StartTime, reserva.EndTime})
                .IsUnique();

            modelBuilder.Entity<SalaDeReuniao>().ToTable("Salas");
            modelBuilder.Entity<Reserva>().ToTable("Reservas");
        }
    }
}

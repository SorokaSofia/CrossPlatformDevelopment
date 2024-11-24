using Lab7.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceBooking> ServiceBookings { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<MechanicsOnService> MechanicsOnServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфігурація таблиці ServiceBooking
            modelBuilder.Entity<ServiceBooking>()
                .HasOne(sb => sb.Customer)
                .WithMany(c => c.ServiceBookings)
                .HasForeignKey(sb => sb.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Заборонити каскадне видалення

            modelBuilder.Entity<ServiceBooking>()
                .HasOne(sb => sb.Car)
                .WithMany(c => c.ServiceBookings)
                .HasForeignKey(sb => sb.LicenceNumber)
                .OnDelete(DeleteBehavior.Cascade); // Каскадне видалення для авто

            // Конфігурація таблиці MechanicsOnService
            modelBuilder.Entity<MechanicsOnService>()
                .HasOne(mos => mos.Mechanic)
                .WithMany(m => m.MechanicsOnServices)
                .HasForeignKey(mos => mos.MechanicId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MechanicsOnService>()
                .HasOne(mos => mos.ServiceBooking)
                .WithMany()
                .HasForeignKey(mos => mos.SvcBookingId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}

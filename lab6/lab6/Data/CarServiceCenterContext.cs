using Microsoft.EntityFrameworkCore;

namespace Lab6.Data
{
    public class CarServiceCenterContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceBooking> ServiceBookings { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<MechanicsOnServices> MechanicsOnServices { get; set; }

        public CarServiceCenterContext(DbContextOptions<CarServiceCenterContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MechanicsOnServices>()
                .HasKey(mos => new { mos.MechanicId, mos.SvcBookingId });

            modelBuilder.Entity<MechanicsOnServices>()
                .HasOne(mos => mos.Mechanic)
                .WithMany(m => m.MechanicsOnServices)
                .HasForeignKey(mos => mos.MechanicId);

            modelBuilder.Entity<MechanicsOnServices>()
                .HasOne(mos => mos.ServiceBooking)
                .WithMany(sb => sb.MechanicsOnServices)
                .HasForeignKey(mos => mos.SvcBookingId);
        }
    }
}

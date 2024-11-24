using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab7.Models
{
    public class MechanicsOnService
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Mechanic")]
        public int MechanicId { get; set; }

        [ForeignKey("ServiceBooking")]
        public int SvcBookingId { get; set; }

        // Навігаційні властивості
        public Mechanic Mechanic { get; set; } = null!;
        public ServiceBooking ServiceBooking { get; set; } = null!;
    }
}

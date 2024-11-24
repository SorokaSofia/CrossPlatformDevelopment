using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab7.Models
{
    public class Car
    {
        [Key]
        public string LicenceNumber { get; set; } = string.Empty;

        [ForeignKey("Model")]
        public string ModelCode { get; set; } = string.Empty;

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public int CurrentMileage { get; set; }
        public double EngineSize { get; set; }
        public string OtherCarDetails { get; set; } = string.Empty;

        // Навігаційні властивості
        public Model Model { get; set; } = null!;
        public Customer Customer { get; set; } = null!;

        // Додати навігаційну властивість для ServiceBookings
        public List<ServiceBooking> ServiceBookings { get; set; } = new();
    }
}

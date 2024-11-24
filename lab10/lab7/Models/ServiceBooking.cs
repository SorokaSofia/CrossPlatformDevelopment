using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab7.Models
{
    public class ServiceBooking
    {
        [Key]
        public int SvcBookingId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Car")]
        public string LicenceNumber { get; set; } = string.Empty;

        public bool PaymentReceivedYn { get; set; }
        public DateTime DatetimeOfService { get; set; }
        public string OtherSvcBookingDetails { get; set; } = string.Empty;

        // Навігаційні властивості
        public Customer Customer { get; set; } = null!;
        public Car Car { get; set; } = null!;
    }
}

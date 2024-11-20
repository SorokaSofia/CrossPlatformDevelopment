using System.Collections.Generic;

namespace Lab6.Data
{
    public class Car
    {
        public int Id { get; set; } // Первинний ключ
        public string LicenceNumber { get; set; } = string.Empty;
        public string OtherCarDetails { get; set; } = string.Empty;

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<ServiceBooking> ServiceBookings { get; set; } = new List<ServiceBooking>();
    }
}

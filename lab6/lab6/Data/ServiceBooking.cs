using System.Collections.Generic;

namespace Lab6.Data
{
    public class ServiceBooking
    {
        public int Id { get; set; } // Первинний ключ
        public string LicenceNumber { get; set; } = string.Empty;
        public string OtherSvcBookingDetails { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public ICollection<MechanicsOnServices> MechanicsOnServices { get; set; } = new List<MechanicsOnServices>();
    }
}

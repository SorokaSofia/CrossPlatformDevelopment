namespace Lab6.Data
{
    public class MechanicsOnServices
    {
        public int MechanicId { get; set; }
        public Mechanic Mechanic { get; set; }

        public int SvcBookingId { get; set; }
        public ServiceBooking ServiceBooking { get; set; }
    }
}

using System.Collections.Generic;

namespace Lab6.Data
{
    public class Mechanic
    {
        public int Id { get; set; } // Первинний ключ
        public string MechanicName { get; set; } = string.Empty;
        public string OtherMechanicDetails { get; set; } = string.Empty;

        public ICollection<MechanicsOnServices> MechanicsOnServices { get; set; } = new List<MechanicsOnServices>();
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public class Mechanic
    {
        [Key]
        public int MechanicId { get; set; }
        public string MechanicName { get; set; } = string.Empty;
        public string OtherMechanicDetails { get; set; } = string.Empty;

        // Навігаційна властивість
        public List<MechanicsOnService> MechanicsOnServices { get; set; } = new();
    }
}

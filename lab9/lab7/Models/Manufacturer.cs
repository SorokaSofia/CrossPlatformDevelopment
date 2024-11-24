using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab7.Models
{
    public class Manufacturer
    {
        [Key]
        public string ManufacturerCode { get; set; } = string.Empty;
        public string ManufacturerName { get; set; } = string.Empty;
        public string OtherManufacturerDetails { get; set; } = string.Empty;

        // Навігаційна властивість
        public List<Model> Models { get; set; } = new();
    }
}

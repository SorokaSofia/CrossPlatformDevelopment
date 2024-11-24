using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab7.Models
{
    public class Model
    {
        [Key]
        public string ModelCode { get; set; } = string.Empty;

        [ForeignKey("Manufacturer")]
        public string ManufacturerCode { get; set; } = string.Empty;

        public string ModelName { get; set; } = string.Empty;
        public string OtherModelDetails { get; set; } = string.Empty;

        // Навігаційні властивості
        public Manufacturer Manufacturer { get; set; } = null!;
        public List<Car> Cars { get; set; } = new();
    }
}

using System.Collections.Generic;

namespace Lab6.Data
{
    public class Model
    {
        public int Id { get; set; } // Первинний ключ
        public string ModelName { get; set; } = string.Empty;
        public string OtherModelDetails { get; set; } = string.Empty;

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}

using System.Collections.Generic;

namespace Lab6.Data
{
    public class Manufacturer
    {
        public int Id { get; set; } // Первинний ключ
        public string ManufacturerName { get; set; } = string.Empty;
        public string OtherManufacturerDetails { get; set; } = string.Empty;

        public ICollection<Model> Models { get; set; } = new List<Model>();
    }
}

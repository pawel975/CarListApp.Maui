using SQLite;

namespace CarListApp.Maui.Models
{
    [Table("cars")]
    public class Car : BaseEnitity
    {
        public string Make { get; set; }
        public string Model { get; set; }
        [MaxLength(12), Unique]
        public string Vin { get; set; }
    }
}

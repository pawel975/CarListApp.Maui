using SQLite;

namespace CarListApp.Maui.Models
{
    public abstract class BaseEnitity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}

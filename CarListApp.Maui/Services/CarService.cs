using CarListApp.Maui.Models;
using SQLite;

namespace CarListApp.Maui.Services
{
    public class CarService
    {
        private SQLiteConnection conn;
        private readonly string _dbPath;
        public string StatusMessage;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Car>();
        }

        public CarService(string dbPath)
        {
            _dbPath = dbPath;
        }
        public List<Car> GetCars()
        {
            try
            {
                Init();
                return conn.Table<Car>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return new List<Car>();

        }
    }
}

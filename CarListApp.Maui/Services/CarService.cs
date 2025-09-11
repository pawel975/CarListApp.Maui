using CarListApp.Maui.Models;
using SQLite;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace CarListApp.Maui.Services
{
    public class CarService
    {
        private SQLiteConnection conn;
        private readonly string _dbPath;
        public string StatusMessage;
        public int result;

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

        public Car? GetCar(int id)
        {
            try
            {
                Init();
                return conn.Table<Car>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to retrieve data.";
            }

            return null;
        }

        public int DeleteCar(int id)
        {
            try
            {
                Init();
                return conn.Table<Car>().Delete(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to delete data.";
            }

            return 0;
        }

        public void UpdateCar(Car car)
        {
            try
            {
                Init();

                if (car == null)
                    throw new Exception("Invalid Car Record");

                result = conn.Update(car);
                StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Update data.";
            }
        }

        public void AddCar(Car car)
        {
            try
            {
                Init();

                if (car == null)
                    throw new Exception("Invalid Car Record");

                result = conn.Insert(car);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Insert data.";
            }
        }
    }
}

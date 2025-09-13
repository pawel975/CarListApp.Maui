using CarListApp.Maui.Models;
using CarListApp.Maui.Services;

namespace CarListApp.Maui
{
    public partial class App : Application
    {
        public static CarDatabaseService CarService { get; private set; }
        public App(CarDatabaseService carService)
        {
            InitializeComponent();

            MainPage = new AppShell();
            CarService = carService;
        }
    }
}
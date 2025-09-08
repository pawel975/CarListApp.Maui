using CarListApp.Maui.ViewModels;

namespace CarListApp.Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly CarListViewModel carListViewModel;
        int count = 0;

        public MainPage(CarListViewModel carListViewModel)
        {
            InitializeComponent();
            BindingContext = carListViewModel;

        }
    }
}

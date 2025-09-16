using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.Maui.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await DisplayLoginError();
                EraseLoginFormData();
            }
            else
            {
                var loginSuccessful = true;

                if (loginSuccessful)
                {
                    // Display 
                }
            }

            await DisplayLoginError();
            EraseLoginFormData();
        }

        private async Task DisplayLoginError()
        {
            await Shell.Current.DisplayAlert("Invalid Attempt", "Invalid username or password", "OK");
        }

        private void EraseLoginFormData()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}

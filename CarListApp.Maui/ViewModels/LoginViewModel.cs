using CarListApp.Maui.Models;
using CarListApp.Maui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarListApp.Maui.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(CarApiService carApiService)
        {
            this.carApiService = carApiService;
        }
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;
        private readonly CarApiService carApiService;

        [RelayCommand]
        async Task Login()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                await DisplayLoginMessage("Invalid login attempt");
                EraseLoginFormData();
            }
            else
            {
                var loginModel = new LoginModel(username, password);

                var response = await carApiService.Login(loginModel);
                await DisplayLoginMessage(carApiService.StatusMessage);

                if (!string.IsNullOrWhiteSpace(response.Token))
                {
                    await SecureStorage.SetAsync("Token", response.Token);
                    var jsonToken = new JwtSecurityTokenHandler().ReadToken(response.Token) as JwtSecurityToken;

                    App.UserInfo = new UserInfo()
                    {
                        Username = username,
                        Role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value
                    };

                    await Shell.Current.GoToAsync($"/{nameof(MainPage)}");

                }
                else
                {
                    await DisplayLoginMessage("Invalid login attempt");
                }

                var loginSuccessful = true;

                if (loginSuccessful)
                {
                    // Display 
                }
            }

            await DisplayLoginMessage("Invalid login attempt");
            EraseLoginFormData();
        }

        private async Task DisplayLoginMessage(string message)
        {
            await Shell.Current.DisplayAlert("Login Attempt Result", message, "OK");
        }

        private void EraseLoginFormData()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}

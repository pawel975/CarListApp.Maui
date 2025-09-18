using CarListApp.Maui.Helpers;
using CarListApp.Maui.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CarListApp.Maui.ViewModels
{
    public partial class LoadingPageViewModel : BaseViewModel
    {
        public LoadingPageViewModel()
        {
            CheckUserLoginDetails();
        }

        private async Task CheckUserLoginDetails()
        {
            var token = await SecureStorage.GetAsync("Token");

            if (token == null)
            {
                await GoToLoginPage();
            }
            else
            {
                var jsonToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                if (jsonToken.ValidTo < DateTime.UtcNow)
                {
                    SecureStorage.Remove("Token");
                    await GoToLoginPage();
                }
                else
                {
                    App.UserInfo = new UserInfo()
                    {
                        Username = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Email))?.Value,
                        Role = jsonToken.Claims.FirstOrDefault(q => q.Type.Equals(ClaimTypes.Role))?.Value
                    };
                    MenuBuilder.BuildMenu();
                    await GoToMainPage();
                }
            }
        }

        private async Task GoToLoginPage()
        {
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }
        private async Task GoToMainPage()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
    }
}

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
                await GoToMainPage();
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

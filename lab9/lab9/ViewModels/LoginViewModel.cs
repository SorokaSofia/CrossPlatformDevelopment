using System.Windows.Input;
using Lab9.Services;
using Lab9.Views;
using Microsoft.Maui.Controls;

namespace Lab9.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthService _authService;

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _authService = ServiceLocator.Get<AuthService>();
            LoginCommand = new Command(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            try
            {
                var token = await _authService.LoginAsync(Username, Password);
                _authService.SetAuthToken(token);
                
                await Shell.Current.GoToAsync($"//MainPage");
            }
            catch (Exception ex)
            {
                ErrorMessage = "Login failed: " + ex.Message;
            }
        }
    }
}

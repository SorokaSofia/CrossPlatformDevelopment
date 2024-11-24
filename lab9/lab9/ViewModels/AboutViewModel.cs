using System.Windows.Input;

namespace Lab9.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public string AppName => "Lab7Client";
        public string Version => "1.0.0";
        public string Description => "This is a cross-platform thin client for Lab7 API, built using .NET MAUI.";

        public ICommand BackCommand { get; }

        public AboutViewModel()
        {
            BackCommand = new Command(async () => await Shell.Current.GoToAsync("//MainPage"));
        }
    }
}

using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Lab9.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand NavigateToModelsCommand { get; }
        public ICommand NavigateToMechanicsCommand { get; }
        public ICommand NavigateToAboutCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel()
        {
            NavigateToModelsCommand = new Command(async () => await Shell.Current.GoToAsync("//ModelsPage"));
            NavigateToMechanicsCommand = new Command(async () => await Shell.Current.GoToAsync("//MechanicsPage"));
            NavigateToAboutCommand = new Command(async () => await Shell.Current.GoToAsync("//AboutPage"));
            LogoutCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//LoginPage");
            });
        }
    }
}

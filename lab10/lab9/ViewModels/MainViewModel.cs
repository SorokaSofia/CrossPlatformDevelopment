using System.Windows.Input;

namespace Lab9.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand NavigateToCustomersCommand { get; }
        public ICommand NavigateToMechanicsCommand { get; }
        public ICommand NavigateToModelsCommand { get; }

        public MainViewModel()
        {
            NavigateToCustomersCommand = new Command(async () =>
                await Shell.Current.GoToAsync("//CustomersView"));

            NavigateToMechanicsCommand = new Command(async () =>
                await Shell.Current.GoToAsync("//MechanicsView"));

            NavigateToModelsCommand = new Command(async () =>
                await Shell.Current.GoToAsync("//ModelsView"));
        }
    }
}

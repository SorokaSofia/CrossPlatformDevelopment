using System.Collections.ObjectModel;
using System.Windows.Input;
using Lab9.Models;
using Lab9.Services;

namespace Lab9.ViewModels
{
    public class MechanicsViewModel : BaseViewModel
    {
        private readonly MechanicsService _mechanicsService;
        public ObservableCollection<Mechanic> Mechanics { get; } = new();
        public ICommand LoadMechanicsCommand { get; }
        public ICommand BackCommand { get; }

        public MechanicsViewModel()
        {
            _mechanicsService = ServiceLocator.Get<MechanicsService>();
            LoadMechanicsCommand = new Command(async () => await LoadMechanics());
            BackCommand = new Command(async () => await Shell.Current.GoToAsync("//MainPage"));
        }

        private async Task LoadMechanics()
        {
            IsBusy = true;
            Mechanics.Clear();
            var mechanics = await _mechanicsService.GetMechanicsAsync();
            foreach (var mechanic in mechanics)
            {
                Mechanics.Add(mechanic);
            }
            IsBusy = false;
        }
    }
}

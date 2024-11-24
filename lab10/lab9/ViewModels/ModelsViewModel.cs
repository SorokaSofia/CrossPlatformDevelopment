using System.Collections.ObjectModel;
using System.Windows.Input;
using Lab9.Models;
using Lab9.Services;

namespace Lab9.ViewModels
{
    public class ModelsViewModel : BaseViewModel
    {
        private readonly ModelsService _modelsService;
        public ObservableCollection<Model> Models { get; } = new();
        public ICommand LoadModelsCommand { get; }
        public ICommand BackCommand { get; }

        public ModelsViewModel()
        {
            _modelsService = ServiceLocator.Get<ModelsService>();
            LoadModelsCommand = new Command(async () => await LoadModels());
            BackCommand = new Command(async () => await Shell.Current.GoToAsync("//MainPage"));
        }

        private async Task LoadModels()
        {
            IsBusy = true;
            Models.Clear();
            var models = await _modelsService.GetModelsAsync();
            foreach (var model in models)
            {
                Models.Add(model);
            }
            IsBusy = false;
        }
    }
}

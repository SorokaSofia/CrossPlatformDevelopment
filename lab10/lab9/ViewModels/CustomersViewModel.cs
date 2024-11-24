using System.Collections.ObjectModel;
using System.Windows.Input;
using Lab9.Models;
using Lab9.Services;

namespace Lab9.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        private readonly CustomersService _customersService;
        public ObservableCollection<Customer> Customers { get; } = new();
        public ICommand LoadCustomersCommand { get; }
        public ICommand BackCommand { get; }

        public CustomersViewModel()
        {
            _customersService = ServiceLocator.Get<CustomersService>();
            LoadCustomersCommand = new Command(async () => await LoadCustomers());
            BackCommand = new Command(async () => await Shell.Current.GoToAsync("//MainPage"));
        }

        private async Task LoadCustomers()
        {
            IsBusy = true;
            Customers.Clear();
            var customers = await _customersService.GetCustomersAsync();
            foreach (var customer in customers)
            {
                Customers.Add(customer);
            }
            IsBusy = false;
        }
    }
}

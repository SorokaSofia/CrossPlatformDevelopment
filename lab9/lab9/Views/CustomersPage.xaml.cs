using Lab9.ViewModels;

namespace Lab9.Views
{
    public partial class CustomersPage : ContentPage
    {
        public CustomersPage()
        {
            InitializeComponent();
            BindingContext = new CustomersViewModel();
        }
    }
}

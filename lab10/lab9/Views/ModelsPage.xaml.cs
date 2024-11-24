using Lab9.ViewModels;

namespace Lab9.Views
{
    public partial class ModelsPage : ContentPage
    {
        public ModelsPage()
        {
            InitializeComponent();
            BindingContext = new ModelsViewModel();
        }
    }
}

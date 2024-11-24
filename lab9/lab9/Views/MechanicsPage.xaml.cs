using Lab9.ViewModels;

namespace Lab9.Views
{
    public partial class MechanicsPage : ContentPage
    {
        public MechanicsPage()
        {
            InitializeComponent();
            BindingContext = new MechanicsViewModel();
        }
    }
}

namespace Lab9.Views
{
    public partial class StatisticsPage : ContentPage
    {
        public StatisticsPage()
        {
            InitializeComponent();
            BindingContext = new StatisticsViewModel();
        }
    }
}

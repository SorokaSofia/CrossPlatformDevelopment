using Microcharts;

namespace Lab7Client.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        public Chart Chart { get; }

        public StatisticsViewModel()
        {
            var entries = new[]
            {
                new ChartEntry(200) { Label = "January", ValueLabel = "200", Color = SkiaSharp.SKColor.Parse("#266489") },
                new ChartEntry(400) { Label = "February", ValueLabel = "400", Color = SkiaSharp.SKColor.Parse("#68B9C0") },
                new ChartEntry(100) { Label = "March", ValueLabel = "100", Color = SkiaSharp.SKColor.Parse("#90D585") }
            };

            Chart = new LineChart { Entries = entries };
        }
    }
}

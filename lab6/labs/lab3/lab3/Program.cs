using SSoroka;
using System.IO;

namespace lab3
{
    public class Program
    {
        public static void Main()
        {
            Run("INPUT.TXT", "OUTPUT.TXT");
        }

        public static void Run(string inputFile, string outputFile)
        {
            var calculator = new WaterFlowCalculator();
            int drainCount = calculator.CalculateDrainCount(inputFile);
            File.WriteAllText(outputFile, drainCount.ToString());
        }
    }
}

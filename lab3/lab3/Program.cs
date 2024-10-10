using SSoroka;

public class Program
{
    public static void Main()
    {
        var calculator = new WaterFlowCalculator();
        int drainCount = calculator.CalculateDrainCount("INPUT.TXT");
        File.WriteAllText("OUTPUT.TXT", drainCount.ToString());
    }
}

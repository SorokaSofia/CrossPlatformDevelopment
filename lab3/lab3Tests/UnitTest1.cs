namespace lab3Tests;

public class UnitTest1
{
    [Fact]
    public void Test_SimpleFlatTerrain()
    {
        var input = new string[]
        {
            "3 3",
            "1 1 1",
            "1 1 1",
            "1 1 1"
        };
        Console.WriteLine("Test Case: Simple Flat Terrain");
        int drainCount = RunTestWithInput(input);
        Console.WriteLine($"Expected: 1, Actual: {drainCount}");
        
        Assert.Equal(1, drainCount);
    }


    [Fact]
    public void Test_HighHillTerrain()
    {
        var input = new string[]
        {
            "3 3",
            "5 5 5",
            "5 5 5",
            "5 5 5"
        };
        Console.WriteLine("Test Case: High Hill Terrain");
        int drainCount = RunTestWithInput(input);
        Console.WriteLine($"Expected: 1, Actual: {drainCount}");
        
        Assert.Equal(1, drainCount);
    }

    [Fact]
    public void Test_OneLowerNeighbor()
    {
        var input = new string[]
        {
            "3 3",
            "2 2 2",
            "2 1 2",
            "2 2 2"
        };
        Console.WriteLine("Test Case: One Lower Neighbor");
        int drainCount = RunTestWithInput(input);
        Console.WriteLine($"Expected: 1, Actual: {drainCount}");
        
        Assert.Equal(1, drainCount);
    }

    [Fact]
    public void Test_ComplexConnectedArea()
    {
        var input = new string[]
        {
            "5 5",
            "5 5 5 5 5",
            "5 3 3 3 5",
            "5 3 2 3 5",
            "5 3 3 3 5",
            "5 5 5 5 5"
        };
        Console.WriteLine("Test Case: Complex Connected Area");
        int drainCount = RunTestWithInput(input);
        Console.WriteLine($"Expected: 1, Actual: {drainCount}");
        
        Assert.Equal(1, drainCount);
    }

    [Fact]
    public void Test_ValleyScenario()
    {
        var input = new string[]
        {
            "4 4",
            "6 6 6 6",
            "6 4 4 6",
            "6 4 4 6",
            "6 6 6 6"
        };
        Console.WriteLine("Test Case: Valley Scenario");
        int drainCount = RunTestWithInput(input);
        Console.WriteLine($"Expected: 1, Actual: {drainCount}");
        
        Assert.Equal(1, drainCount);
    }

    private int RunTestWithInput(string[] input)
    {
        File.WriteAllLines("INPUT.TXT", input);

        Program.Main();

        var output = File.ReadAllText("OUTPUT.TXT");
        return int.Parse(output);
    }
}

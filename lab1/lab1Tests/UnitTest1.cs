using System;
using System.Collections.Generic;
using Xunit;

public class lab1Tests
{  
    [Fact]
    public void Test_SolutionCount_For5Points()
    {
        int points = 5;
        var solutions = Program.GenerateSolutions(points);
        Console.WriteLine($"Testing for {points} points. Found {solutions.Count} solutions.");
        Assert.Equal(7, solutions.Count);
    }

    [Fact]
    public void Test_IsFinalThrowValid_Bull()
    {
        bool isValid = Program.IsFinalThrowValid("Bull");
        Console.WriteLine($"Testing if 'Bull' is a valid final throw: {isValid}");
        Assert.True(isValid);
    }

    [Fact]
    public void Test_IsFinalThrowValid_Double()
    {
        bool isValid = Program.IsFinalThrowValid("D20");
        Console.WriteLine($"Testing if 'D20' is a valid final throw: {isValid}");
        Assert.True(isValid);
    }

    [Fact]
    public void Test_IsFinalThrowInvalid_Triple()
    {
        bool isValid = Program.IsFinalThrowValid("T20");
        Console.WriteLine($"Testing if 'T20' is a valid final throw: {isValid}");
        Assert.False(isValid);
    }

    [Fact]
    public void Test_NoSolutionsForImpossiblePoints()
    {
        int points = 1;
        var solutions = Program.GenerateSolutions(points);
        Console.WriteLine($"Testing for {points} points. Found {solutions.Count} solutions.");
        Assert.Empty(solutions);
    }

    [Fact]
    public void Test_SolutionCount_For50Points()
    {
        int points = 50;
        var solutions = Program.GenerateSolutions(points);
        Console.WriteLine($"Testing for {points} points. Found {solutions.Count} solutions.");
        Assert.NotEmpty(solutions);
    }
}

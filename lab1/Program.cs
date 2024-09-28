using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "INPUT.TXT";
        int points = int.Parse(File.ReadAllText(inputFilePath).Trim());

        List<(string, int)> dartScores = new List<(string, int)>
        {
            ("Bull", 50), ("25", 25)
        };

        for (int i = 1; i <= 20; i++)
        {
            dartScores.Add((i.ToString(), i));   
            dartScores.Add(("D" + i, 2 * i));   
            dartScores.Add(("T" + i, 3 * i));   
        }

        List<List<string>> solutions = new List<List<string>>();

        for (int i = 0; i < dartScores.Count; i++)
        {
            if (dartScores[i].Item2 == points && IsFinalThrowValid(dartScores[i].Item1))
            {
                solutions.Add(new List<string> { dartScores[i].Item1 });
            }

            for (int j = 0; j < dartScores.Count; j++)
            {
                if (dartScores[i].Item2 + dartScores[j].Item2 == points && IsFinalThrowValid(dartScores[j].Item1))
                {
                    solutions.Add(new List<string> { dartScores[i].Item1, dartScores[j].Item1 });
                }

                for (int k = 0; k < dartScores.Count; k++)
                {
                    if (dartScores[i].Item2 + dartScores[j].Item2 + dartScores[k].Item2 == points && IsFinalThrowValid(dartScores[k].Item1))
                    {
                        solutions.Add(new List<string> { dartScores[i].Item1, dartScores[j].Item1, dartScores[k].Item1 });
                    }
                }
            }
        }

        
        string outputFilePath = "OUTPUT.TXT";
        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            writer.WriteLine(solutions.Count);
            foreach (var solution in solutions)
            {
                writer.WriteLine(string.Join(" ", solution));
            }
        }
    }


    static bool IsFinalThrowValid(string dart)
    {
        return dart.StartsWith("D") || dart == "Bull";
    }
}

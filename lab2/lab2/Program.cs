﻿using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllText("INPUT.TXT").Split();
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        int[,] dp = new int[N + K + 1, K + 1];

        dp[N, 0] = 1;

        for (int step = 1; step <= K; step++)
        {
            for (int pos = 0; pos <= N + K; pos++)
            {
                dp[pos, step] = 0;
                if (pos - 1 >= 0)
                {
                    dp[pos, step] += dp[pos - 1, step - 1];
                }
                if (pos + 1 <= N + K)
                {
                    dp[pos, step] += dp[pos + 1, step - 1];
                }
            }
        }

        int result = dp[0, K];
        
        for (int step = 1; step < K; step++)
        {
            result -= dp[0, step];
        }

        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }
}
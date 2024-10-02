using System;
using Xunit;

namespace lab2Tests
{
    public class UnitTest1
    {
        private void PrintIntermediateResult(string message)
        {
            Console.WriteLine(message);
        }

        [Fact]
        public void Test_N2_K4_ShouldReturn2()
        {
            PrintIntermediateResult("Starting test Test_N2_K4_ShouldReturn2");
            int N = 2;
            int K = 4;

            int result = CalculateWaysToStore(N, K);

            Assert.Equal(2, result);
            PrintIntermediateResult("Test Test_N2_K4_ShouldReturn2 passed successfully");
        }

        [Fact]
        public void Test_N5_K5_ShouldReturn1()
        {
            PrintIntermediateResult("Starting test Test_N5_K5_ShouldReturn1");
            int N = 5;
            int K = 5;

            int result = CalculateWaysToStore(N, K);

            Assert.Equal(1, result);
            PrintIntermediateResult("Test Test_N5_K5_ShouldReturn1 passed successfully");
        }

        [Fact]
        public void Test_N1_K1_ShouldReturn1()
        {
            PrintIntermediateResult("Starting test Test_N1_K1_ShouldReturn1");
            int N = 1;
            int K = 1;

            int result = CalculateWaysToStore(N, K);

            Assert.Equal(1, result);
            PrintIntermediateResult("Test Test_N1_K1 passed successfully");
        }

        [Fact]
        public void Test_N3_K5_ShouldReturn3()
        {
            PrintIntermediateResult("Starting test Test_N3_K5_ShouldReturn3");
            int N = 3;
            int K = 5;

            int result = CalculateWaysToStore(N, K);

            Assert.Equal(3, result);
            PrintIntermediateResult("Test Test_N3_K5 passed successfully");
        }

        [Fact]
        public void Test_N4_K6_ShouldReturn4()
        {
            PrintIntermediateResult("Starting test Test_N4_K6_ShouldReturn4");
            int N = 4;
            int K = 6;

            int result = CalculateWaysToStore(N, K);

            Assert.Equal(4, result);
            PrintIntermediateResult("Test Test_N4_K6 passed successfully");
        }

        private int CalculateWaysToStore(int N, int K)
        {
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

            return result;
        }
    }
}

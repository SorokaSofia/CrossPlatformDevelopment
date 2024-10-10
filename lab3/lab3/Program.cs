public class Program
{
    public static int N, M;
    public static int[,] grid = null!;
    public static bool[,] visited = null!;
    public static int[] dRow = { -1, 1, 0, 0 };
    public static int[] dCol = { 0, 0, -1, 1 };
    
    public static void Main()
    {
        var input = File.ReadAllLines("INPUT.TXT");
        var dimensions = input[0].Split();
        N = int.Parse(dimensions[0]);
        M = int.Parse(dimensions[1]);

        grid = new int[N, M];
        visited = new bool[N, M];

        for (int i = 0; i < N; i++)
        {
            var row = input[i + 1].Split();
            for (int j = 0; j < M; j++)
            {
                grid[i, j] = int.Parse(row[j]);
            }
        }

        int drainCount = 0;

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (!visited[i, j])
                {
                    if (!CanWaterFlow(i, j))
                    {
                        drainCount++;
                    }
                }
            }
        }

        File.WriteAllText("OUTPUT.TXT", drainCount.ToString());
    }

    public static bool CanWaterFlow(int row, int col)
    {
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((row, col));
        visited[row, col] = true;
        bool hasLowerNeighbor = false;

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();
        
            for (int i = 0; i < 4; i++)
            {
                int newRow = r + dRow[i];
                int newCol = c + dCol[i];

                if (IsInBounds(newRow, newCol))
                {
                    if (grid[newRow, newCol] < grid[r, c])
                    {
                        hasLowerNeighbor = true;
                    }
                    else if (grid[newRow, newCol] == grid[r, c] && !visited[newRow, newCol])
                    {
                        visited[newRow, newCol] = true;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
        }

        return hasLowerNeighbor;
    }

    public static bool IsInBounds(int row, int col)
    {
        return row >= 0 && row < N && col >= 0 && col < M;
    }
}


namespace SSoroka
{
    public class WaterFlowCalculator
    {
        public int N, M;
        public int[,] grid = null!;
        public bool[,] visited = null!;
        public int[] dRow = { -1, 1, 0, 0 };
        public int[] dCol = { 0, 0, -1, 1 };

        public int CalculateDrainCount(string inputFilePath)
        {
            // Зчитування даних з файлу
            var input = File.ReadAllLines(inputFilePath);
            var dimensions = input[0].Split();
            N = int.Parse(dimensions[0]);
            M = int.Parse(dimensions[1]);

            // Ініціалізація сітки та масиву відвіданих клітинок
            grid = new int[N, M];
            visited = new bool[N, M];

            // Заповнення сітки висотами
            for (int i = 0; i < N; i++)
            {
                var row = input[i + 1].Split();
                for (int j = 0; j < M; j++)
                {
                    grid[i, j] = int.Parse(row[j]);
                }
            }

            int drainCount = 0;

            // Перевірка кожної клітинки
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (!visited[i, j] && !CanWaterFlow(i, j))
                    {
                        drainCount++;
                    }
                }
            }

            return drainCount;
        }

        private bool CanWaterFlow(int row, int col)
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
                        // Перевірка на наявність сусіда з меншою висотою
                        if (grid[newRow, newCol] < grid[r, c])
                        {
                            hasLowerNeighbor = true;
                        }
                        // Перевірка на рівну висоту та невідвідані клітинки
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

        private bool IsInBounds(int row, int col)
        {
            // Перевірка, чи знаходиться клітинка в межах сітки
            return row >= 0 && row < N && col >= 0 && col < M;
        }
    }
}

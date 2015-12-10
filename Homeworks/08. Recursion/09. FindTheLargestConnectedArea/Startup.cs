namespace _09.FindTheLargestConnectedArea
{
    using System;

    public class Startup
    {
        private static char[,] labyrinth =
                          {
                                {' ', ' ', ' ', 'x', ' ', ' ', ' '},
                                {'x', 'x', ' ', 'x', ' ', 'x', ' '},
                                {' ', 'x', ' ', ' ', ' ', 'x', ' '},
                                {' ', 'x', 'x', 'x', 'x', 'x', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '}
                            };

        private static int[] start = new int[] { 0, 0 };
        private static int count = 0;
        private static int maxCount = 0;

        public static void Main()
        {
            StartCounting();
            Console.WriteLine("Max path is {0}", maxCount);
        }

        private static void StartCounting()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] != 'x')
                    {
                        CountPaths(i, j);
                    }

                    count = 0;
                }
            }
        }

        private static void CountPaths(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) ||
                col < 0 || col >= labyrinth.GetLength(1) ||
                labyrinth[row, col] == 'x')
            {
                return;
            }

            count++;
            if (maxCount < count)
            {
                maxCount = count;
            }

            labyrinth[row, col] = 'x';
            CountPaths(row + 1, col);
            CountPaths(row - 1, col);
            CountPaths(row, col + 1);
            CountPaths(row, col - 1);
        }
    }
}
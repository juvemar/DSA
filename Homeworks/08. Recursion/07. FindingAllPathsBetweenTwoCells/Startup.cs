namespace _07.FindingAllPathsBetweenTwoCells
{
    using System;

    public class Startup
    {
        private static char[,] labyrint =
                          {
                                {' ', ' ', ' ', 'x', ' ', ' ', ' '},
                                {'x', 'x', ' ', 'x', ' ', 'x', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                {' ', 'x', 'x', 'x', 'x', 'x', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                            };
        private static int[] start = new int[] { 0, 0 };
        private static int[] end = new int[] { 4, 6 };
        private static int count = 0;

        public static void Main()
        {
            CountPaths(start[0], start[1]);
            Console.WriteLine("The number of paths is {0}", count);
        }

        private static void CountPaths(int row, int col)
        {
            if (row < 0 || row >= labyrint.GetLength(0) ||
                col < 0 || col >= labyrint.GetLength(1))
            {
                return;
            }

            if (row == end[0] && col == end[1])
            {
                count++;
                return;
            }

            if (labyrint[row, col] != 'x')
            {
                labyrint[row, col] = 'x';
                CountPaths(row + 1, col);
                CountPaths(row - 1, col);
                CountPaths(row, col + 1);
                CountPaths(row, col - 1);
                labyrint[row, col] = ' ';
            }
        }
    }
}

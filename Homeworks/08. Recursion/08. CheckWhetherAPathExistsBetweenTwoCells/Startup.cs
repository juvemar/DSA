namespace _08.CheckWhetherAPathExistsBetweenTwoCells
{
    using System;

    public class Startup
    {
        private static char[,] labyrinth =
                          {
                                {' ', ' ', ' ', 'x', ' ', ' ', ' '},
                                {'x', 'x', ' ', 'x', ' ', 'x', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                                {' ', 'x', 'x', 'x', 'x', 'x', ' '},
                                {' ', ' ', ' ', ' ', ' ', ' ', ' '},
                            };

        //private static char[,] labyrinth = new char[100, 100];

        private static int[] start = new int[] { 0, 0 };
        private static int[] end = new int[] { 4, 6 };
        //private static int[] end = new int[] { 99, 99 };

        public static void Main()
        {
            Console.WriteLine("Is there a path between [{0},{1}] and [{2},{3}]?", start[0], start[1], end[0], end[1]);
            CheckPath(start[0], start[1]);
            Console.WriteLine("No!");
        }

        private static void CheckPath(int row, int col)
        {
            if (row < 0 || row >= labyrinth.GetLength(0) ||
                col < 0 || col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (row == end[0] && col == end[1])
            {
                Console.WriteLine("Yes!");
                Environment.Exit(0);
            }

            if (labyrinth[row, col] != 'x')
            {
                labyrinth[row, col] = 'x';
                CheckPath(row + 1, col);
                CheckPath(row - 1, col);
                CheckPath(row, col + 1);
                CheckPath(row, col - 1);
            }
        }
    }
}

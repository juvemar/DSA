namespace _01.Portals
{
    using System;
    using System.Linq;

    // Recursion
    public class Startup
    {
        private const int NumberZero = 0;
        private const int NumberOne = 1;

        private static int maxValue = 0;
        private static char[,] matrix;
        private static bool[,] isPassable;

        public static void Main()
        {
            var xY = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var startRow = xY[0];
            var startCol = xY[1];

            var rC = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var rows = rC[0];
            var cols = rC[1];

            matrix = new char[rows, cols];
            isPassable = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col][0];
                }
            }

            var currentCount = 0;
            CountPortals(startRow, startCol, currentCount);

            Console.WriteLine(maxValue);

            //Print(matrix, rows, cols);
        }

        private static void CountPortals(int startRow, int startCol, int currentCount)
        {
            if (!IsPossibleCell(startRow, startCol))
            {
                return;
            }

            if (maxValue < currentCount)
            {
                maxValue = currentCount;
            }

            if (!IsPossibleCell(startRow, startCol))
            {
                return;
            }

            isPassable[startRow, startCol] = true;

            var currentValue = int.Parse(matrix[startRow, startCol].ToString());
            currentCount += currentValue;

            if (startRow - currentValue >= NumberZero)
            {
                CountPortals(startRow - currentValue, startCol, currentCount);
            }

            if (startCol + currentValue < matrix.GetLength(NumberOne))
            {
                CountPortals(startRow, startCol + currentValue, currentCount);
            }

            if (startRow + currentValue < matrix.GetLength(NumberZero))
            {
                CountPortals(startRow + currentValue, startCol, currentCount);
            }

            if (startCol - currentValue >= NumberZero)
            {
                CountPortals(startRow, startCol - currentValue, currentCount);
            }

            isPassable[startRow, startCol] = false;
        }

        private static bool IsPossibleCell(int startRow, int startCol)
        {
            if (matrix[startRow, startCol] == '#')
            {
                return false;
            }

            if (isPassable[startRow, startCol])
            {
                return false;
            }

            return true;
        }

        private static void Print(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
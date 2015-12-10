namespace _02._3DLabyrinth
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static string[, ,] labyrinth;
        private static int minPath = int.MaxValue;
        private static int currentPath = 0;

        public static void Main()
        {
            var startPosition = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var dimentions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            labyrinth = new string[dimentions[0], dimentions[1], dimentions[2]];

            for (int i = 0; i < dimentions[0]; i++)
            {
                for (int j = 0; j < dimentions[1]; j++)
                {
                    var line = Console.ReadLine();
                    for (int k = 0; k < dimentions[2]; k++)
                    {
                        labyrinth[i, j, k] = line[k].ToString();
                    }
                }
            }

            WalkThroughMatrix(startPosition);

            Console.WriteLine(minPath);
        }

        private static void WalkThroughMatrix(int[] currentPosition)
        {
            var depth = currentPosition[0];
            var row = currentPosition[1];
            var col = currentPosition[2];

            if (row < 0 || row >= labyrinth.GetLength(1) ||
                col < 0 || col >= labyrinth.GetLength(2))
            {
                return;
            }

            if (depth < 0 || depth >= labyrinth.GetLength(0))
            {
                if (minPath > currentPath)
                {
                    minPath = currentPath;
                }

                return;
            }

            if (labyrinth[depth, row, col] != "#")
            {
                currentPath++;

                if (labyrinth[depth, row, col] == "D")
                {
                    if (depth > 0)
                    {
                        if (labyrinth[depth - 1, row, col] != "U")
                        {
                            var changeDown = new int[] { currentPosition[0] - 1, currentPosition[1], currentPosition[2] };
                            WalkThroughMatrix(changeDown);
                        }
                        else
                        {
                            labyrinth[depth, row, col] = "#";
                            labyrinth[depth - 1, row, col] = "#";
                        }
                    }
                    else if (depth == 0)
                    {
                        var changeDown = new int[] { currentPosition[0] - 1, currentPosition[1], currentPosition[2] };
                        WalkThroughMatrix(changeDown);
                    }
                }
                else if (labyrinth[depth, row, col] == "U")
                {
                    if (depth < labyrinth.GetLength(0) - 1)
                    {
                        if (labyrinth[depth + 1, row, col] != "D")
                        {
                            var changeUp = new int[] { currentPosition[0] + 1, currentPosition[1], currentPosition[2] };
                            WalkThroughMatrix(changeUp);
                        }
                        else
                        {
                            labyrinth[depth, row, col] = "#";
                            labyrinth[depth + 1, row, col] = "#";
                        }
                    }
                    else if (depth == labyrinth.GetLength(0) - 1)
                    {
                        var changeDown = new int[] { currentPosition[0] + 1, currentPosition[1], currentPosition[2] };
                        WalkThroughMatrix(changeDown);
                    }
                }

                labyrinth[depth, row, col] = "#";

                var changeColRight = new int[] { currentPosition[0], currentPosition[1], currentPosition[2] + 1 };
                WalkThroughMatrix(changeColRight);

                var changeRowDown = new int[] { currentPosition[0], currentPosition[1] + 1, currentPosition[2] };
                WalkThroughMatrix(changeRowDown);

                var changeColLeft = new int[] { currentPosition[0], currentPosition[1], currentPosition[2] - 1 };
                WalkThroughMatrix(changeColLeft);

                var changeRowUp = new int[] { currentPosition[0], currentPosition[1] - 1, currentPosition[2] };
                WalkThroughMatrix(changeRowUp);
                labyrinth[depth, row, col] = " ";
            }
        }

        private static void PrintInputMatrix()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    for (int k = 0; k < labyrinth.GetLength(2); k++)
                    {
                        Console.Write(labyrinth[i, j, k]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

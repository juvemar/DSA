namespace _14.Labyrinth
{
    using System;

    public class Startup
    {
        private static string[,] matrix;
        private static int startX;
        private static int startY;

        public static void Main()
        {
            int n = 6;
            FillInitialMatrix(n);
            FillMatrix();

            DrawResultMatrix();
        }

        private static void FillInitialMatrix(int n)
        {
            matrix = new string[n, n];

            matrix[0, 3] = "x";
            matrix[0, 5] = "x";
            matrix[1, 1] = "x";
            matrix[1, 3] = "x";
            matrix[1, 5] = "x";
            matrix[2, 2] = "x";
            matrix[2, 4] = "x";
            matrix[3, 1] = "x";
            matrix[3, 5] = "x";
            matrix[4, 3] = "x";
            matrix[4, 4] = "x";
            matrix[5, 3] = "x";
            matrix[5, 5] = "x";
            matrix[2, 1] = "*";

            FillNullWithU();
        }

        private static void FillNullWithU()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[i, y] == null)
                    {
                        matrix[i, y] = "u";
                    }
                }
            }
        }

        private static void FillMatrix()
        {
            var startPoint = FindStartPoint();
            if (startPoint == null)
            {
                throw new ArgumentException("There is no start point!");
            }

            startX = startPoint[0];
            startY = startPoint[1];
            var number = 1;
            WalkThrowMatrix(startX, startY, number);
        }

        private static int[] FindStartPoint()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[i, y] == "*")
                    {
                        return new int[] { i, y };
                    }
                }
            }

            return null;
        }

        private static void WalkThrowMatrix(int x, int y, int number)
        {
            //go down
            if (x + 1 != matrix.GetLength(0) - 1 && matrix[x + 1, y] != "x")
            {
                if (matrix[x + 1, y] == null)
                {
                    matrix[x + 1, y] = number.ToString();
                    WalkThrowMatrix(x + 1, y, ++number);
                }

                WalkThrowMatrix(x + 1, y, ++number);
            }

            //go left
            if (y - 1 != 0)
            {
                if (matrix[x, y - 1] == null)
                {
                    matrix[x, y - 1] = number.ToString();
                    WalkThrowMatrix(x, y - 1, ++number);
                }

                WalkThrowMatrix(x, y - 1, ++number);
            }

            //go up
            if (x - 1 != 0)
            {
                if (matrix[x - 1, y] == null)
                {
                    matrix[x - 1, y] = number.ToString();
                    WalkThrowMatrix(x - 1, y, ++number);
                }

                WalkThrowMatrix(x - 1, y, ++number);
            }

            //go right
            if (y + 1 != matrix.GetLength(1) - 1 && matrix[x, y + 1] != "x")
            {
                if (matrix[x, y + 1] == null)
                {
                    matrix[x, y + 1] = number.ToString();
                    WalkThrowMatrix(x, y + 1, ++number);
                }

                WalkThrowMatrix(x, y + 1, ++number);
            }
            //FillMatrix();
        }

        private static void DrawResultMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("|");
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[i, y] == null && y != matrix.GetLength(1) - 1)
                    {
                        Console.Write(" " + " ");
                    }
                    else
                        if (matrix[i, y] == null && y == matrix.GetLength(1) - 1)
                        {
                            Console.Write(" ");
                        }
                        else
                            if (y == matrix.GetLength(1) - 1)
                            {
                                Console.Write(matrix[i, y]);
                            }
                            else
                            {
                                Console.Write(matrix[i, y] + " ");
                            }
                }
                Console.Write("|\n");
            }
        }

        private static bool CheckIfMatrixIsFull()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[i, y] == null)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

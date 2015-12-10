namespace _03.ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        private static char[] possibleDirs = { 'L', 'R', 'S' };
        private static Queue<char> combinationsOrder = new Queue<char>();
        private static int starsCount;
        private static StringBuilder builder = new StringBuilder();

        public static void Main()
        {
            var path = Console.ReadLine();
            starsCount = path.ToCharArray().Where(x => x == '*').Count();

            if (starsCount == 0)
            {
                builder.AppendLine("1");
                builder.Append(path);
            }
            else
            {
                var stars = new char[starsCount];
                var arr = new char[starsCount];

                SortCombinations(arr, 0);
                var combinationsCount = Math.Pow(3, starsCount);
                builder.AppendLine(Math.Pow(3, starsCount).ToString());

                for (int i = 0; i < combinationsCount; i++)
                {
                    for (int j = 0; j < path.Length; j++)
                    {
                        if (path[j] == '*')
                        {
                            builder.Append(combinationsOrder.Dequeue());
                        }
                        else
                        {
                            builder.Append(path[j]);
                        }
                    }

                    builder.Append("\n");
                }
            }

            Console.WriteLine(builder);
        }

        private static void SortCombinations(char[] arr, int index)
        {
            if (index == arr.Length)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    combinationsOrder.Enqueue(arr[i]);
                }

                return;
            }

            for (int i = 0; i < possibleDirs.Length; i++)
            {
                arr[index] = possibleDirs[i];
                SortCombinations(arr, index + 1);
            }
        }
    }
}

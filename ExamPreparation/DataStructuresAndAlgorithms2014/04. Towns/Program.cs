using System;

namespace _04.Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var towns = new int[n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                towns[i] = int.Parse(line[0]);
            }

            var upPaths = new int[n];
            for (int i = 0; i < n; i++)
            {
                upPaths[i] = 1;
                for (int j = i; j >= 0; j--)
                {
                    if (towns[i] > towns[j])
                    {
                        upPaths[i] = Math.Max(upPaths[i], upPaths[j] + 1);
                    }
                }
            }

            var downPaths = new int[n];

            for (int i = n - 1; i >= 0; i--)
            {
                downPaths[i] = 1;
                for (int j = i; j < n; j++)
                {
                    if (towns[i] > towns[j])
                    {
                        downPaths[i] = Math.Max(downPaths[i], downPaths[j] + 1);
                    }
                }
            }

            var maxPath = 0;
            for (int i = 0; i < n; i++)
            {
                if (downPaths[i] + upPaths[i] - 1 > maxPath)
                {
                    maxPath = downPaths[i] + upPaths[i] - 1;
                }
            }

            Console.WriteLine(maxPath);
        }
    }
}

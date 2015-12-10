namespace _05.Guitar
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] songsVolumes = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int startVolume = int.Parse(Console.ReadLine());
            var maxVolume = int.Parse(Console.ReadLine());

            var currentVolume = startVolume;
            bool[,] table = new bool[songsVolumes.Length + 1, maxVolume + 1];

            table[0, startVolume] = true;

            for (int row = 1; row <= songsVolumes.Length; row++)
            {
                for (int col = 0; col <= maxVolume; col++)
                {
                    //if (col + songsVolumes[row - 1] > maxVolume && col - songsVolumes[row - 1] < 0 && table[row - 1, col])
                    //{
                    //    Console.WriteLine(-1);
                    //    Environment.Exit(0);
                    //}

                    if (table[row - 1, col] && col - songsVolumes[row - 1] >= 0)
                    {
                        table[row, col - songsVolumes[row - 1]] = true;
                    }

                    if (table[row - 1, col] && col + songsVolumes[row - 1] <= maxVolume)
                    {
                        table[row, col + songsVolumes[row - 1]] = true;
                    }
                }
            }

            for (int k = table.GetLength(1) - 1; k >= 0; k--)
            {
                if (table[songsVolumes.Length, k])
                {
                    Console.WriteLine(k);
                    Environment.Exit(0);
                }
            }

            Console.WriteLine(-1);
        }
    }
}

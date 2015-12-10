namespace _03.FriendsInNeed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var mapParams = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var points = mapParams[0];
            var streets = mapParams[1];
            var hospitalsCount = mapParams[2];
            var hospitals = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var hospitalsList = new LinkedList<int>(hospitals);

            var graf = new int[points + 1, points + 1];
            for (int i = 0; i < streets; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < hospitalsCount; j++)
                {
                    if (hospitalsList.Contains(line[0]))
                    {
                        graf[line[0], line[1]] = line[2];
                    }
                    else
                    {
                        graf[line[1], line[0]] = line[2];
                    }
                }
            }

            var minValue = int.MaxValue;

            for (int i = 1; i <= hospitalsCount; i++)
            {
                var currentValue = 0;
                for (int j = 1; j <= points - hospitalsCount; j++)
                {
                    if (!hospitalsList.Contains(j))
                    {
                        currentValue += graf[i, j];
                    }
                }

                if (minValue > currentValue)
                {
                    minValue = currentValue;
                }
            }

            Console.WriteLine(minValue);
        }
    }
}

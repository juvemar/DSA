namespace Election
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Startup
    {
        private static int k;
        private static int[] seats;
        private static BigInteger count = 0;

        //public static void Main()
        //{
        //    k = int.Parse(Console.ReadLine());
        //    var n = int.Parse(Console.ReadLine());

        //    seats = new int[n];

        //    for (int i = 0; i < n; i++)
        //    {
        //        seats[i] = int.Parse(Console.ReadLine());
        //    }

        //    Subsets(seats);

        //    Console.WriteLine(count);
        //}

        private static void Subsets(int[] numbers)
        {
            var combinations = new BigInteger[numbers.Sum() + 1];
            combinations[0] = 1;
            long maxSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (long j = maxSum; j >= 0; j--)
                {
                    if (combinations[j] > 0)
                    {
                        var current = j + numbers[i];
                        combinations[current] += combinations[j];

                        if (current > maxSum)
                        {
                            maxSum = current;
                        }
                    }
                }
            }

            for (int i = k; i <= maxSum; i++)
            {
                count += combinations[i];
            }
        }

        private static void Subsets2(int[] numbers)
        {
            var test = new List<long>();
            test.Add(0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentResults = new List<long>();
                var number = numbers[i];
                var testL = test.Count;

                for (int j = 0; j < testL; j++)
                {
                    var current = test[j] + number;

                    if (current >= k)
                    {
                        count++;
                    }

                    test.Add(current);
                }
            }
        }
    }
}
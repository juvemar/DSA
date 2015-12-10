namespace _01.Election
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class MySolution
    {
        private static int k;
        private static int[] seats;
        private static BigInteger count = 0;
        private static BigInteger[] combinations;

        public static void Main()
        {
            k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            seats = new int[n];
            for (int i = 0; i < n; i++)
            {
                seats[i] = int.Parse(Console.ReadLine());
            }

            combinations = new BigInteger[seats.Sum() + 1];

            CombineSeats(seats);
            CountCombinations();

            Console.WriteLine(count);
        }

        private static void CombineSeats(int[] seats)
        {
            combinations[0] = 1;
            var maxSum = 0;
            var currentSum = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                currentSum += seats[i];
                for (int j = maxSum; j >= 0; j--)
                {
                    if (combinations[j] != 0)
                    {
                        combinations[j + seats[i]] += combinations[j];
                    }
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
            }
        }

        private static void CountCombinations()
        {
            for (int i = combinations.Length - 1; i >= k; i--)
            {
                count += combinations[i];
            }
        }
    }
}

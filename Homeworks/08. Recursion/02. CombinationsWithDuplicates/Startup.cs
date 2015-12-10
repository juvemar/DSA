namespace _02.CombinationsWithDuplicates
{
    using System;

    public class Startup
    {
        private static int n;
        private static int k;
        private static int value = 1;
        private static int index = 0;
        private static int[] arr;

        public static void Main()
        {
            n = 3;
            k = 2;
            arr = new int[k];

            GenerateCombinations(arr, index, value);
        }

        private static void GenerateCombinations(int[] arr, int index, int value)
        {
            if (index == k)
            {
                Print();
                return;
            }

            for (int i = value; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, index + 1, value);
                value++;
            }
        }

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(" ", arr));
        }
    }
}

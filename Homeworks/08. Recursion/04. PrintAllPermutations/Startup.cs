namespace _04.PrintAllPermutations
{
    using System;

    public class Startup
    {
        private static int k;
        private static int n;
        private static int[] arr;

        public static void Main()
        {
            k = 3;
            n = 3;
            arr = new int[k];
            GenerateVariations(0);
        }

        public static void GenerateVariations(int index)
        {
            if (index == k)
            {
                Console.WriteLine("({0})", string.Join(" ", arr));
                return;
            }

            for (int i = 1; i < n; i++)
            {
                arr[index] = i;
                GenerateVariations(index + 1);
            }
        }
    }
}
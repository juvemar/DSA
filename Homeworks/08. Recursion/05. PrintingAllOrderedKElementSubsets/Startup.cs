namespace _05.PrintingAllOrderedKElementSubsets
{
    using System;

    public class Startup
    {
        private static int n;
        private static int k;
        private static int index = 0;
        private static int second = 0;
        private static string[] arr = { "hi", "a", "b" };
        private static string[] result;

        public static void Main()
        {
            k = 2;
            n = 3;
            result = new string[k];
            GenerateVariations(index, second);
        }

        static void GenerateVariations(int index, int second)
        {
            if (second >= k || index >= n)
            {
                PrintVariations();
                return;
            }

            for (int i = index; i < n; i++)
            {
                result[second] = arr[i];
                GenerateVariations(index, second + 1);
            }
        }

        private static void PrintVariations()
        {
            Console.WriteLine("({0})", string.Join(" ", result));
        }
    }
}
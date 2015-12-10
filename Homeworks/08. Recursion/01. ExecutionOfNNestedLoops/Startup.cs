using System;

namespace _01.ExecutionOfNNestedLoops
{
    public class Startup
    {
        private static int n;
        private static int index = 0;

        public static void Main()
        {
            n = 2;
            var arr = new int[n];
            GenerateCombinations(arr, index);
        }

        private static void GenerateCombinations(int[] arr, int index)
        {
            if (index == n)
            {
                Console.WriteLine("({0})", string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, index + 1);
            }
        }
    }
}

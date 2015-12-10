namespace _03.CombinationsWithoutDuplicates
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static int n;
        private static int k;
        private static int value = 1;
        private static int index = 0;
        private static int[] arr;

        public static void Main()
        {
            n = 4;
            k = 2;
            arr = new int[k];

            GenerateCombinations(arr, index, value);
        }

        private static void GenerateCombinations(int[] arr, int index, int value)
        {
            if (arr.All(x => x == n))
            {
                return;
            }

            if (index == k)
            {
                Print();
                return;
            }

            for (int i = value; i <= n; i++)
            {
                if (index > 0)
                {
                    for (int j = 0; j < index; j++)
                    {
                        if (arr[j] == i)
                        {
                            if (i + 1 > n)
                            {
                                break;
                            }

                            i++;
                        }

                        if (j == index - 1)
                        {
                            arr[index] = i;
                        }
                    }
                }
                else
                {
                    arr[index] = i;
                }
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

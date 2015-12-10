namespace _04.PrintAllPermutationsTillN
{
    using System;

    public class Startup
    {
        private static int n;
        private static int[] arr;

        public static void Main()
        {
            n = 3;
            arr = new int[n];
            FillArray();
            PermuteRep(0, arr.Length);
        }

        private static void FillArray()
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }
        }

        static void PermuteRep(int start, int n)
        {
            Print();

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(left + 1, n);
                    }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                    arr[n - 1] = firstElement;
                }
            }
        }

        private static void Swap(ref int v1, ref int v2)
        {
            var swapper = v1;
            v1 = v2;
            v2 = swapper;
        }

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(" ", arr));
        }
    }
}

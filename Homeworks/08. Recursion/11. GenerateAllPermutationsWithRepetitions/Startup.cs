namespace _11.GenerateAllPermutationsWithRepetitions
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var arr = new int[] { 1, 3, 5, 5 };
            Array.Sort(arr);
            PermuteRep(arr, 0, arr.Length);
        }


        private static void PermuteRep(int[] arr, int start, int n)
        {
            Print(arr);

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n);
                    }
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

        private static void Print(int[] arr)
        {
            Console.WriteLine("{" + string.Join(", ", arr) + "}");
        }
    }
}

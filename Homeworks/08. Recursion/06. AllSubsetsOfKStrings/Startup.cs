namespace _06.AllSubsetsOfKStrings
{
    using System;

    public class Startup
    {
        private static int k;
        private static int index = 0;
        private static int second = 0;
        private static string[] arr = { "test", "rock", "fun" };
        private static string[] result;

        public static void Main()
        {
            k = 2;
            result = new string[k];
            GenerateVariations(index, second);
        }

        static void GenerateVariations(int index, int second)
        {
            if (second >= k)
            {
                PrintVariations();
                return;
            }

            for (int i = index; i < arr.Length; i++)
            {
                result[second] = arr[i];
                GenerateVariations(index + 1, second + 1);
                index++;
            }
        }

        private static void PrintVariations()
        {
            Console.WriteLine("({0})", string.Join(" ", result));
        }
    }
}

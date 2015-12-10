namespace _03.SortIntegersIncreasingly
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Please enter numbers on separate lines:");
            List<int> list = ReadInput();
            list.Sort();

            Console.WriteLine(string.Join(", ", list));
        }
        private static List<int> ReadInput()
        {
            var input = Console.ReadLine();
            var list = new List<int>();

            while (!string.IsNullOrEmpty(input))
            {
                list.Add(int.Parse(input));

                input = Console.ReadLine();
            }

            return list;
        }
    }
}

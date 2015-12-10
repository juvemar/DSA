namespace _07.CountEachNumberOccurence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var array = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            var dictionary = new Dictionary<int, int>();

            //first decision
            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, array.Count(x => x == item));
                }
            }

            dictionary.ToList().ForEach(x => Console.WriteLine("{0} - {1} times", x.Key, x.Value));

            //second decision
            Console.WriteLine();
            array.GroupBy(n => n)
                .ToList()
                .ForEach(n => Console.WriteLine("{0} - {1} times", n.Key, n.Count()));
        }
    }
}

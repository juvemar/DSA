using System;
using System.Collections.Generic;

namespace _01.CountDoubleOccurences
{
    public class Startup
    {
        public static void Main()
        {
            var dictionary = new Dictionary<double, int>();
            var array = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            for (int i = 0; i < array.Length; i++)
            {
                if (!dictionary.ContainsKey(array[i]))
                {
                    dictionary.Add(array[i], 0);
                }

                dictionary[array[i]]++;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}

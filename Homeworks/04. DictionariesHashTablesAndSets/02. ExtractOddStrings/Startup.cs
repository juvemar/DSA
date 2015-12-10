namespace _02.ExtractOddStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            var array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            for (int i = 0; i < array.Length; i++)
            {
                if (!dictionary.ContainsKey(array[i]))
                {
                    dictionary.Add(array[i], 0);
                }

                dictionary[array[i]]++;
            }

            dictionary.AsQueryable()
                .Where(s => s.Value % 2 != 0)
                .ToList()
                .ForEach(s => Console.WriteLine(s.Key));
        }
    }
}

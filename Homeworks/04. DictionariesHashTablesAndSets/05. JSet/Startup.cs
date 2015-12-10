namespace _05.JSet
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var set1 = new MySet<string>();
            var set2 = new MySet<string>();

            set1.Add("one");
            set1.Add("two");
            set1.Add("three");

            set2.Add("three");
            set2.Add("four");

            Console.WriteLine(set1);
            Console.WriteLine(set2);

            Console.WriteLine(set1.Intersect(set2));
            Console.WriteLine(set2.Intersect(set1));

            Console.WriteLine(set1.Union(set2));
            Console.WriteLine(set2.Union(set1));

            set1.Remove("five");
            set1.Remove("two");
            Console.WriteLine(set1);

            Console.WriteLine(set1.Contains("one"));
            Console.WriteLine(set1.Contains("two"));

            Console.WriteLine(set1.Count);
        }
    }
}

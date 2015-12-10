namespace _02.CollectionOfProducts
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private const decimal Price = 30.5m;
        private static OrderedBag<Product> products = new OrderedBag<Product>();

        public static void Main()
        {
            var timer = new Stopwatch();
            timer.Start();
            var product = new Product();

            for (int i = 0; i < 500000; i++)
            {
                product.Name = "Sol" + i.ToString();
                product.Price = Price + i + 0.5m;
            }

            for (int i = 0; i < 10000; i++)
            {
                var resultProducts = SearchTwentyProductsInRange(100.5m, 210.0m);
            }

            timer.Stop();
            Console.WriteLine("Needed time: {0}", timer.Elapsed);
        }

        private static IEnumerable SearchTwentyProductsInRange(decimal min, decimal max)
        {
            var result = products
                .Where(p => p.Price >= min && p.Price <= max)
                .Take(20);

            return result;
        }
    }
}

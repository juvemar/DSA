namespace _05.ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Product
    {
        public Product(string name, string producer, decimal price)
        {
            this.Name = name;
            this.Producer = producer;
            this.Price = price;
        }

        public string Name { get; set; }

        public string Producer { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }

    public class Startup
    {
        private static Dictionary<string, Bag<Product>> productsByName = new Dictionary<string, Bag<Product>>();
        private static Dictionary<string, Bag<Product>> productsByProducer = new Dictionary<string, Bag<Product>>();
        private static Dictionary<decimal, Bag<Product>> productsByPrice = new Dictionary<decimal, Bag<Product>>();
        private static StringBuilder builder = new StringBuilder();

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                var commandName = line.Substring(0, line.IndexOf(" "));
                var commandParams = line.Substring(line.IndexOf(" ") + 1).Split(';');

                if (commandName == "AddProduct")
                {
                    var name = commandParams[0].Trim();
                    var producer = commandParams[2].Trim();
                    var price = decimal.Parse(commandParams[1].Trim(), CultureInfo.InvariantCulture);
                    AddProduct(name, producer, price);
                }
                else if (commandName == "DeleteProducts")
                {
                    if (commandParams.Length == 1)
                    {
                        var producer = commandParams[0].Trim();
                        DeleteByProducer(producer);
                    }
                    else
                    {
                        var name = commandParams[0].Trim();
                        var producer = commandParams[1].Trim();
                        DeleteByProducer(name, producer);
                    }
                }
                else if (commandName == "FindProductsByName")
                {
                    var name = commandParams[0].Trim();
                    FindProductsByName(name);
                }
                else if (commandName == "FindProductsByPriceRange")
                {
                    var minPrice = decimal.Parse(commandParams[0].Trim(), CultureInfo.InvariantCulture);
                    var maxPrice = decimal.Parse(commandParams[1].Trim(), CultureInfo.InvariantCulture);
                    FindProcutsByPriceRange(minPrice, maxPrice);
                }
                else
                {
                    var producer = commandParams[0].Trim();
                    FindProductsByProducer(producer);
                }
            }

            Console.WriteLine(builder.ToString());
        }

        private static void FindProductsByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                builder.AppendLine("No products found");
                return;
            }

            var result = productsByProducer[producer]
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Producer)
                .ThenBy(p => p.Price)
                .ToList();

            foreach (var product in result)
            {
                builder.AppendLine(product.ToString());
            }
        }

        private static void FindProcutsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var result = productsByPrice.Where(pr => pr.Key >= minPrice && pr.Key <= maxPrice)
                .SelectMany(p => p.Value)
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Producer)
                .ThenBy(p => p.Price)
                .ToList();

            if (result.Count == 0)
            {
                builder.AppendLine("No products found");
                return;
            }

            foreach (var product in result)
            {
                builder.AppendLine(product.ToString());
            }
        }

        private static void FindProductsByName(string name)
        {
            if (!productsByName.ContainsKey(name))
            {
                builder.AppendLine("No products found");
                return;
            }

            var result = productsByName[name]
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Producer)
                .ThenBy(p => p.Price)
                .ToList();

            foreach (var product in result)
            {
                builder.AppendLine(product.ToString());
            }
        }

        private static void AddProduct(string name, string producer, decimal price)
        {
            var product = new Product(name, producer, price);

            if (!productsByName.ContainsKey(name))
            {
                productsByName.Add(name, new Bag<Product>() { product });
            }
            else
            {
                productsByName[name].Add(product);
            }

            if (!productsByProducer.ContainsKey(producer))
            {
                productsByProducer.Add(producer, new Bag<Product>() { product });
            }
            else
            {
                productsByProducer[producer].Add(product);
            }

            if (!productsByPrice.ContainsKey(price))
            {
                productsByPrice.Add(price, new Bag<Product>() { product });
            }
            else
            {
                productsByPrice[price].Add(product);
            }

            builder.AppendLine("Product added");
        }

        private static void DeleteByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                builder.AppendLine("No products found");
                return;
            }

            var lengthBeforeDelete = productsByProducer[producer].Count();
            builder.AppendFormat("{0} products deleted" + "\n", lengthBeforeDelete);
            productsByProducer.Remove(producer);

            foreach (var pair in productsByName)
            {
                pair.Value.RemoveAll(p => p.Producer == producer);
            }

            foreach (var pair in productsByPrice)
            {
                pair.Value.RemoveAll(p => p.Producer == producer);
            }
        }

        private static void DeleteByProducer(string name, string producer)
        {
            if (!productsByName.ContainsKey(name) || !productsByProducer.ContainsKey(producer))
            {
                builder.AppendLine("No products found");
                return;
            }

            var lengthBeforeDelete = productsByProducer[producer].Count();
            builder.AppendFormat("{0} products deleted" + "\n", lengthBeforeDelete);
            productsByProducer[producer].RemoveAll(p => p.Name == name);
            var lengthAfterDelete = lengthBeforeDelete - productsByProducer[producer].Count();
            productsByName[name].RemoveAll(p => p.Producer == producer);

            foreach (var pair in productsByPrice)
            {
                pair.Value.RemoveAll(p => p.Producer == producer && p.Name == name);
            }
        }
    }
}

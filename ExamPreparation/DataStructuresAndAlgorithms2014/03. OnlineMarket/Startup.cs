namespace _03.OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    // Data structures
    public class Product
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + this.Price + ")";
        }

        public int CompareTo(Product other)
        {
            if (this.Price.CompareTo(other.Price) == 0)
            {
                if (this.Name.CompareTo(other.Name) == 0)
                {
                    if (this.Type.CompareTo(other.Type) == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return this.Type.CompareTo(other.Type);
                    }
                }
                else
                {
                    return this.Name.CompareTo(other.Name);
                }
            }

            return this.Price.CompareTo(other.Price);
        }
    }

    public class Startup
    {
        private static Dictionary<string, HashSet<Product>> productsByType = new Dictionary<string, HashSet<Product>>();
        private static Dictionary<double, HashSet<Product>> prices = new Dictionary<double, HashSet<Product>>();
        private static HashSet<string> names = new HashSet<string>();
        private static StringBuilder builder = new StringBuilder();

        public static void Main()
        {
            var line = string.Empty;

            while ((line = Console.ReadLine()) != "end")
            {
                var commandName = line.Substring(0, line.IndexOf(" "));
                var commandParams = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commandName == "add")
                {
                    var name = commandParams[1];
                    if (!names.Contains(name))
                    {
                        var price = double.Parse(commandParams[2], CultureInfo.InvariantCulture);
                        var type = commandParams[3];
                        AddProduct(name, price, type);
                    }
                    else
                    {
                        builder.AppendFormat("Error: Product {0} already exists\n", name);
                    }
                }
                else
                {
                    var filterType = commandParams[2];

                    if (filterType == "type")
                    {
                        var type = commandParams[3];
                        FilterProductsByType(type);
                    }
                    else
                    {
                        var priceFilterType = commandParams[3];
                        if (priceFilterType == "to")
                        {
                            var maxPrice = double.Parse(commandParams[4], CultureInfo.InvariantCulture);
                            FilterProductsWithLessPriceThanMax(maxPrice);
                        }
                        else if (commandParams.Length > 5)
                        {
                            var minPrice = double.Parse(commandParams[4], CultureInfo.InvariantCulture);
                            var maxPrice = double.Parse(commandParams[6], CultureInfo.InvariantCulture);

                            FilterProductsByPriceRange(minPrice, maxPrice);
                        }
                        else
                        {
                            var minPrice = double.Parse(commandParams[4], CultureInfo.InvariantCulture);

                            FilterProductsWithPriceMoreThanMin(minPrice);
                        }
                    }
                }
            }

            Console.WriteLine(builder);
        }

        private static string JoinFilteredProducts(IEnumerable<Product> filtered)
        {
            var separated = string.Join(", ", filtered.Select(p => string.Format("{0}({1})", p.Name, p.Price)));

            return separated;
        }

        private static void FilterProductsWithPriceMoreThanMin(double minPrice)
        {
            var filtered = prices
                .Where(p => p.Key >= minPrice)
                .SelectMany(v => v.Value)
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            var separated = JoinFilteredProducts(filtered);

            builder.AppendFormat("Ok: {0}\n", string.Join(", ", separated));
        }

        private static void FilterProductsByPriceRange(double minPrice, double maxPrice)
        {
            var filtered = prices
                .Where(p => p.Key >= minPrice && p.Key <= maxPrice)
                .SelectMany(v => v.Value)
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            var separated = JoinFilteredProducts(filtered);

            builder.AppendFormat("Ok: {0}\n", string.Join(", ", separated));
        }

        private static void FilterProductsWithLessPriceThanMax(double maxPrice)
        {
            var filtered = prices
                .Where(p => p.Key <= maxPrice)
                .SelectMany(v => v.Value)
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            var separated = JoinFilteredProducts(filtered);

            builder.AppendFormat("Ok: {0}\n", string.Join(", ", separated));
        }

        private static void FilterProductsByType(string type)
        {
            if (!productsByType.ContainsKey(type))
            {
                builder.AppendFormat("Error: Type {0} does not exists\n", type);
            }
            else
            {
                var filtered = productsByType[type]
                    .OrderBy(x => x.Price)
                    .ThenBy(x => x.Name)
                    .ThenBy(x => x.Type)
                    .Take(10);

                var separated = JoinFilteredProducts(filtered);

                builder.AppendFormat("Ok: {0}\n", string.Join(", ", separated));
            }
        }

        private static void AddProduct(string name, double price, string type)
        {
            var product = new Product(name, price, type);
            names.Add(name);

            if (!productsByType.ContainsKey(type))
            {
                productsByType.Add(type, new HashSet<Product>() { product });
            }
            else
            {
                productsByType[type].Add(product);
            }

            if (!prices.ContainsKey(price))
            {
                prices.Add(price, new HashSet<Product>() { product });
            }
            else
            {
                prices[price].Add(product);
            }

            builder.AppendFormat("Ok: Product {0} added successfully\n", name);
        }
    }
}

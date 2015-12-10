namespace _02.MillionsOfArticles
{
    using System;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private const int BarcodeLength = 10;
        private const int VendorLength = 20;
        private const int TitleLength = 25;
        private const int ArticlesCount = 1000000; //Reduce this const to see the printed result faster :)
        private const int MinPrice = 50;
        private const int MaxPrice = 500;
        private const int NumberOfRangesToPrint = 10;

        private static IRandomGenerator randomGenerator = new RandomGenerator();

        public static void Main()
        {
            var addedArticles = GenerateArticles();
            SearchArticles(addedArticles);
        }

        private static OrderedMultiDictionary<double, Article> GenerateArticles()
        {
            var articles = new OrderedMultiDictionary<double, Article>(true);

            for (int i = 0; i < ArticlesCount; i++)
            {
                var barcode = randomGenerator.GetRandomString(BarcodeLength);
                var vendor = randomGenerator.GetRandomString(VendorLength);
                var title = randomGenerator.GetRandomString(TitleLength);
                var price = randomGenerator.GetRandomDouble(MinPrice, MaxPrice);
                var articleToAdd = new Article(barcode, vendor, title, price);
                articles.Add(price, articleToAdd);
            }

            return articles;
        }

        private static void SearchArticles(OrderedMultiDictionary<double, Article> articles)
        {
            var rangesPrintCount = 0;
            while (rangesPrintCount < 10)
            {
                var minPrice = randomGenerator.GetRandomDouble(50, 500);
                var maxPrice = randomGenerator.GetRandomDouble(Convert.ToInt32(minPrice), 500);

                Console.WriteLine("================= Range -> [{0},{1}] =================", minPrice, maxPrice);
                articles.Range(minPrice, true, maxPrice, true)
                    .ForEach(a =>
                    {
                        foreach (var article in a.Value)
                        {
                            Console.WriteLine(article.ToString());
                        }
                    });

                rangesPrintCount++;
            }
        }
    }
}

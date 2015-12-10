namespace _03.BiDictionaryUsage
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            BiDictionary<int, string, string> bidi = new BiDictionary<int, string, string>();

            var key1 = 1;
            var key2 = "key2";
            bidi.Add(key1, key2, "added keys 1 and 2 once");
            bidi.Add(key1, key2, "added keys 1 and 2 twice");

            Console.WriteLine("Search by key1:");
            Console.WriteLine(bidi.Find(key1));
            Console.WriteLine("Search by key2:");
            Console.WriteLine(bidi.Find(key2));
            Console.WriteLine("Search by key1 and key2:");
            Console.WriteLine(bidi.Find(key1, key2));
        }
    }
}

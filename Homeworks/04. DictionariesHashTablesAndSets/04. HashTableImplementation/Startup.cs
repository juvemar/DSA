namespace _04.HashTableImplementation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var table = new MyHashTable<int, string>();

            for (int i = 0; i < 50; i++)
            {
                table.Add(i, i.ToString());
            }

            Console.WriteLine(table);
            Console.WriteLine(table.Count);
        }
    }
}

namespace _03.FindWords
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Counting words...");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            TrieNode root = new TrieNode(null, '?');

            var args = "../../Text.txt";

            DataReader newReader = new DataReader(args, ref root);
            Thread newThread = new Thread(newReader.ThreadRun);
            newThread.Start();
            newThread.Join();

            stopwatch.Stop();
            Console.WriteLine("Input data processed in {0} seconds", stopwatch.Elapsed);
            Console.WriteLine();

            List<TrieNode> nodes = new List<TrieNode>();

            foreach (var item in root.Nodes)
            {
                nodes.Add(item.Value);
            }

            int distinct_word_count = 0;
            int total_word_count = 0;
            root.GetTopCounts(ref nodes, ref distinct_word_count, ref total_word_count);

            foreach (TrieNode node in nodes)
            {
                Console.WriteLine("{0} - {1} times", node.ToString(), node.m_word_count);
            }

            Console.WriteLine();
            Console.WriteLine("{0} words counted", total_word_count);
            Console.WriteLine("{0} distinct words found", distinct_word_count);
            Console.WriteLine();
            Console.WriteLine("done.");
        }
    }
}

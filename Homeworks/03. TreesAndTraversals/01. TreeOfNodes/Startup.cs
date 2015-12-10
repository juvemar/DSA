namespace _01.TreeOfNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static Dictionary<Node<int>, int> longestPaths = new Dictionary<Node<int>, int>();
        private static int currentPathCount = 1;

        private static HashSet<int> children = new HashSet<int>();

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = new Node<int>[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < n - 1; i++)
            {
                var inputNodes = Console.ReadLine().Split(' ');

                var parentNode = int.Parse(inputNodes[0]);
                var childNode = int.Parse(inputNodes[1]);

                nodes[parentNode].AddChild(nodes[childNode]);
            }

            //01. Find the root
            var root = FindRoot(nodes);
            Console.WriteLine("The root is {0}.", root.Value);
            children.Clear();

            //02. Find leafs
            var leafs = FindLeafs(nodes);
            Console.WriteLine("The leafs are {0}", string.Join(", ", leafs));
            children.Clear();

            //03. Find middle nodes
            var middleNodes = FindMiddleNodes(nodes);
            Console.WriteLine("The middle nodes are {0}", string.Join(", ", middleNodes));
            children.Clear();

            //04. Find longest path
            FindLongestPath(nodes);
            PrintLongestPaths();
        }

        //01. Find the root
        private static Node<int> FindRoot(Node<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    children.Add(child.Value);
                }
            }

            for (int i = 0; i < children.Count(); i++)
            {
                if (!children.Contains(nodes[i].Value))
                {
                    return nodes[i];
                }
            }

            return null;
        }

        //02. Find leafs
        private static IEnumerable<int> FindLeafs(Node<int>[] nodes)
        {
            var children = new HashSet<int>();
            foreach (var node in nodes)
            {
                if (node.Children.Count() == 0)
                {
                    children.Add(node.Value);
                }
            }

            return children;
        }

        //03. Find middle nodes
        private static IEnumerable<int> FindMiddleNodes(Node<int>[] nodes)
        {
            var children = new HashSet<int>();

            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count() != 0)
                {
                    children.Add(node.Value);
                }
            }

            return children;
        }

        //04. Find longest path
        private static void FindLongestPath(Node<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                CountPath(node);
            }
        }

        private static Node<int> CountPath(Node<int> node)
        {
            if (node.Children.Count() == 0)
            {
                var currentLongestPath = 0;
                if (longestPaths.Count() != 0)
                {
                    currentLongestPath = longestPaths.First().Value;
                }

                if (currentPathCount > currentLongestPath)
                {
                    longestPaths.Clear();
                    longestPaths[node] = currentPathCount;
                }
                else if (currentPathCount == longestPaths.First().Value)
                {
                    longestPaths[node] = currentPathCount;
                }

                currentPathCount = 1;

                return null;
            }

            foreach (var child in node.Children)
            {
                currentPathCount++;
                CountPath(child);
            }

            return null;
        }

        private static void PrintLongestPaths()
        {
            Console.WriteLine("Number of levels: {0}", longestPaths.First().Value);

            Console.WriteLine("Longest paths:");
            foreach (var node in longestPaths)
            {
                if (node.Key.HasParent)
                {
                    TakeParent(node.Key);
                }

                Console.Write(string.Join(", ", children));
                children.Clear();
                Console.WriteLine();
            }
        }

        private static void TakeParent(Node<int> node)
        {
            children.Add(node.Value);

            if (node.HasParent)
            {
                TakeParent(node.Parent);
            }
        }
    }
}

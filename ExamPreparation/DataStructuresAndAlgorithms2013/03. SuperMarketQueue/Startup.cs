namespace _03.SuperMarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Startup
    {
        private static BigList<string> people = new BigList<string>();
        private static Dictionary<string, int> names = new Dictionary<string, int>();
        private static StringBuilder builder = new StringBuilder();

        public static void Main()
        {
            string line;

            while ((line = Console.ReadLine()) != "End")
            {
                var current = line.Split(' ');
                var commandName = current[0];
                if (current.Length == 3)
                {
                    var position = int.Parse(current[1]);
                    var name = current[2];
                    if (position > people.Count)
                    {
                        builder.AppendLine("Error");
                    }
                    else
                    {
                        builder.AppendLine("OK");
                        Insert(position, name);
                    }
                }
                else if (commandName == "Append")
                {
                    var name = current[1];
                    AppendName(name);
                }
                else if (commandName == "Serve")
                {
                    var number = int.Parse(current[1]);
                    if (number > people.Count)
                    {
                        builder.AppendLine("Error");
                    }
                    else
                    {
                        Serve(number);
                    }
                }
                else
                {
                    var name = current[1];
                    FindName(name);
                }
            }

            Console.WriteLine(builder);
        }

        private static void FindName(string name)
        {
            if (!names.ContainsKey(name))
            {
                builder.AppendLine("0");
            }
            else
            {
                builder.AppendLine(names[name].ToString());
            }
        }

        private static void Serve(int number)
        {
            var toServe = people.Take(number).ToList();

            builder.AppendLine(string.Join(" ", toServe));

            for (int i = 0; i < number; i++)
            {
                names[toServe[i]]--;
                people.Remove(toServe[i]);
            }
        }

        private static void AppendName(string name)
        {
            builder.AppendLine("OK");
            if (!names.ContainsKey(name))
            {
                names.Add(name, 1);
            }
            else
            {
                names[name]++;
            }

            people.Add(name);
        }

        private static void Insert(int position, string name)
        {
            people.Insert(position, name);
            if (!names.ContainsKey(name))
            {
                names.Add(name, 1);
            }
            else
            {
                names[name]++;
            }
        }
    }
}

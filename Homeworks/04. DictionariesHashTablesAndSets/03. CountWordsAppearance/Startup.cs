namespace _03.CountWordsAppearance
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            var text = "This is the TEXT. Text, text, text - THIS TEXT! Is this the text?";

            var words = text.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "-")
                {
                    continue;
                }

                var word = words[i].ToLower().TrimEnd('.', '?', '!', ',');
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, 0);
                }

                dictionary[word]++;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}

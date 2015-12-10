namespace _02.GirlsGoneWild
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // Combinatorics
    public class Startup
    {
        private static int shirts;
        private static StringBuilder builder = new StringBuilder();
        private static int girlsCount;
        private static int combinations = 0;
        private static char[] skirts;
        private static int firstItemCombs = 0;
        private static int firstLetterCounter = 0;

        public static void Main()
        {
            shirts = int.Parse(Console.ReadLine());
            skirts = Console.ReadLine().ToCharArray().OrderBy(x => x).ToArray();
            girlsCount = int.Parse(Console.ReadLine());
            var used = new HashSet<char>();

            MakeCombinations(0, 0, new string[girlsCount]);

            Console.WriteLine("{0}\n{1}", combinations, builder);
        }

        private static void MakeCombinations(int index, int nextIndex, string[] strArray)
        {
            if (nextIndex == girlsCount)
            {
                var joinCombs = string.Join("-", strArray);
                builder.AppendLine(joinCombs);
                combinations++;
                firstLetterCounter++;

                return;
            }

            for (int i = index; i <= girlsCount; i++)
            {
                var currentLetterCount = skirts.Where(s => s == skirts[index]).Count() - 1;

                firstItemCombs = (shirts - (i + 1)) * (skirts.Distinct().Where(s => s != skirts[index]).Count() + currentLetterCount);

                if (strArray[0] == null)
                {
                    strArray[index] = string.Format("{0}{1}", i, skirts[index]);
                }
                else
                {
                    strArray[nextIndex] = string.Format("{0}{1}", i, skirts[nextIndex]);
                }

                if (firstLetterCounter == firstItemCombs)
                {
                    index++;
                }
                
                MakeCombinations(index, nextIndex + 1, strArray);
            }
        }
    }
}

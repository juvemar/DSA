namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            List<string> masters = new List<string>();
            List<string> knights = new List<string>();
            List<string> padawans = new List<string>();

            Console.ReadLine();
            var jedis = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < jedis.Length; i++)
            {
                switch (jedis[i][0])
                {
                    case 'm':
                        masters.Add(jedis[i]); break;
                    case 'k':
                        knights.Add(jedis[i]); break;
                    default:
                        padawans.Add(jedis[i]); break;
                }
            }

            var sb = new StringBuilder();

            masters.ForEach(q => sb.Append(q + " "));
            knights.ForEach(q => sb.Append(q + " "));
            padawans.ForEach(q => sb.Append(q + " "));

            Console.WriteLine(sb.ToString());
        }
    }
}

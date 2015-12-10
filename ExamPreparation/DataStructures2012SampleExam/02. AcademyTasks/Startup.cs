namespace _02.AcademyTasks
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var problems = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var variety = int.Parse(Console.ReadLine());

            var winPosition = 0;
            var isReady = false;
            for (int i = 1; i < problems.Length; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (Math.Abs(problems[j] - problems[i]) >= variety)
                    {
                        winPosition = i + 1;
                        isReady = true;
                        break;
                    }
                }

                if (isReady)
                {
                    break;
                }
            }

            if (winPosition == 0)
            {
                Console.WriteLine(problems.Length);
            }
            else
            {
                Console.WriteLine(winPosition / 2 + 1);
            }
        }
    }
}

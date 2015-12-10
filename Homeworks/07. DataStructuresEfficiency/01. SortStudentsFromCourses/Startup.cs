namespace _01.SortStudentsFromCourses
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System;

    public class Startup
    {
        private static SortedDictionary<string, List<Student>> students = new SortedDictionary<string, List<Student>>();

        public static void Main()
        {
            var list = new List<Student>();
            using (StreamReader reader = new StreamReader("../../Students.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    var student = new Student(data[0], data[1], data[2]);
                    list.Add(student);
                }
            }

            foreach (var item in list)
            {
                if (!students.ContainsKey(item.Course))
                {
                    students.Add(item.Course, new List<Student> { item });
                }
                else
                {
                    students[item.Course].Add(item);
                }
            }

            students.Values.Select(l => l.OrderBy(s => s.FamilyName).ThenBy(s => s.Name)).ToList();

            foreach (var course in students)
            {
                Console.Write(course.Key.ToString() + ": " + string.Join(", ", course.Value));
                Console.WriteLine();
            }
        }
    }
}

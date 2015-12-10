namespace _01.SortStudentsFromCourses
{
    public class Student
    {
        public Student(string name, string familyName, string course)
        {
            this.Name = name;
            this.FamilyName = familyName;
            this.Course = course;
        }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string Course { get; set; }

        public override string ToString()
        {
            return this.Name + " " + this.FamilyName;
        }
    }
}
namespace lab1.Models
{
    public class Student
    {
        private int id;
        private string name;
        private string faculty;
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Faculty { get { return faculty; } set { faculty = value; } }
    }
}

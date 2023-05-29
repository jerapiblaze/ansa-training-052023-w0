using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task002.Types
{
    public class StudentList
    {
        private List<Student> students;
        internal List<Student> GetStudents()
        {
            return this.students;
        }

        public StudentList()
        {
            students = new List<Student>();
        }

        private void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void ShowInformation()
        {
            foreach (Student student in students)
            {
                Print(student);
               
            }
        }
        private void Print(Student student)
        {
            Console.WriteLine("ID: " + student.Id + ", Name: " + student.Name + ", Total Score: " + student.Score);
        }

        public void InitData(int numStudent)
        {
            Random random = new Random();
            string[] Names = { "Minh", "Nam", "Phong", "Linh", "Hue", "Quang", "Nhat", "Khanh", "Thao", "Trung" };
            for (int i = 1; i <= numStudent; i++)
            {
                string Name = Names[random.Next(Names.Length)];
                int birthYear = random.Next(2000, 2010);
                double score = random.Next(1, 11);

                Student student = new Student(i ,Name ,score);
                students.Add(student);
            }
        }
    }
}
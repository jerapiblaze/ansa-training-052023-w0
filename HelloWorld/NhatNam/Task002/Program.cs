using System;
using System.Collections.Generic;

namespace Program
{
    public class Student
    {
        public string? Name;

        public int ID;

        public string? Class;

        public static int NumberOfStudents = 0;

        // Constructor
        public Student(string Name, int ID, string Class)
        {
            this.Name = Name;
            this.ID = ID;
            this.Class = Class;
            NumberOfStudents++;
        }

        public void printStudent()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Class: " + Class);
        }
    }

    public class Students
    {
        List<Student> students = new List<Student>();

        public void addStudent()
        {
            string Name;
            int ID;
            string Class;

            Console.Write("Enter Name: ");
            Name = Console.ReadLine();
            Console.Write("Enter ID: ");
            ID = Console.ReadLine();
            Console.Write("Enter Class: ");
            Class = Console.ReadLine();

            Student temp = new Student(Name, ID, Class);

            students.Add(temp);
        }

        public int numOfStudents()
        {
            return students.Count;
        }

        public void deleteStudent()
        {
            int ID;

            Console.Write("Enter ID to delete: ");
            ID = Console.ReadLine();

            bool deleted = false;

            foreach (Student i in students)
            {
                if (i.ID == ID)
                {
                    if (students.Remove(i))
                    {
                        deleted = true;
                    }
                    else
                    {
                        Console.WriteLine("Can't remove student");
                    }
                }
            }

            if (!deleted)
            {
                Console.WriteLine("Invalid ID!");
            }
        }




    }
}

using System;
using System.Collections.Generic;

namespace Program
{
    public class Student
    {
        public string? Name;

        public int ID;

        public string? Class;

        // public static int NumberOfStudents = 0;

        // Constructor
        public Student(string Name, int ID, string Class)
        {
            this.Name = Name;
            this.ID = ID;
            this.Class = Class;
            // NumberOfStudents++;
        }

        public void printStudent()
        {
            Console.WriteLine($"Name: {Name}, ID: {ID}, Class: {Class}");
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
            ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Class: ");
            Class = Console.ReadLine();

            Student temp = new Student(Name, ID, Class);

            students.Add(temp);
        }

        public int numOfStudents()
        {
            return students.Count;
        }

        public void printStudents()
        {
            for (int i = 0; i < numOfStudents(); i++)
            {
                Console.Write(i + ". ");
                students[i].printStudent();
            }
        }

        public void deleteStudent()
        {
            int ID;

            Console.Write("Enter ID to delete: ");
            ID = Convert.ToInt32(Console.ReadLine());

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

        public void modifyStudent()
        {
            int ID;

            Console.Write("Enter ID to modify: ");
            ID = Convert.ToInt32(Console.ReadLine());

            string Name;
            string Class;
            Console.Write("Enter new name: ");
            Name = Console.ReadLine();
            Console.Write("Enter new class: ");
            Class = Console.ReadLine();

            bool modified = false;

            foreach (Student i in students)
            {
                if (i.ID == ID)
                {
                    i.Name = Name;
                    i.Class = Class;
                    modified = true;
                }
            }

            if (!modified)
            {
                Console.WriteLine("Invalid ID!");
            }
        }
    }

    static void Main()
    {
        Students listOfStudents = new Students();

        while (true)
        {
            Console.WriteLine("\n\nSelect Options: ");
            Console.WriteLine("     1. Add a Student.");
            Console.WriteLine("     2. Delete a Student.");
            Console.WriteLine("     3. Modify a Student.");
            Console.WriteLine("     4. Show all Students.");
            Console.WriteLine("     5. Quit.");

            Console.Write("\nYour choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    break;

            }

        }


    }
}

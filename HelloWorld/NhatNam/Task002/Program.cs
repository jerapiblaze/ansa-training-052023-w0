using System;

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
}

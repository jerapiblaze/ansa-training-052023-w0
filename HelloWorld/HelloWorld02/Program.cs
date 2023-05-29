using System;

namespace HelloWorld02
{
    class Program
    {
        public static void Main(string[] args)
        {
            ListStudent list = new ListStudent();
            Student hs1 = new Student("1", "A", 9.5);
            Student hs2 = new Student("2", "B", 8.5);
            list.Add(hs1);
            list.Add(hs2);
            list.Remove(hs1);
        }
    }
}
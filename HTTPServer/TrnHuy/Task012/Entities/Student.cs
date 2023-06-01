using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPServer02.Entities
{
    public class Student
    {
        public Student()
        {
        }

        public Student(int id, string name, double point)
        {
            Id = id;
            Name = name;
            Point = point;
        }

        public int Id {set; get;}
        public string Name {set; get;}
        public double Point {set; get;}

        public string ToString()
        {
            return @$"{Id} - {Name} - {Point}";
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld02
{
    public class Student
    {
        public int Id {set; get;}
        public string Name {set; get;}
        public double Point {set; get;}
        public Student(int v1, string v2, double v3)
        {
            Id = v1;
            Name = v2;
            Point = v3;
        }
    }
}
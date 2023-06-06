using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models
{
    public class Student
    {
        public int Id {set; get;}
        public string Name {set; get;}
        public double Point {set; get;}
        public Student(int i, string n, double p)
        {
            Id = i;
            Name= n;
            Point =p;
        }
        public Student()
        {
            Id=0;
            Name="";
            Point=0;
        }
        public override string ToString()
        {
            return $@"{Id}-{Name}-{Point}";
        }
    }
}
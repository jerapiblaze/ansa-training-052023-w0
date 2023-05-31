using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace _0._1._2
{
    public class Student
    {
        public string name{get;set;}
        public int id{get;set;}
        public Student(){}
        public Student(string aName, int aID)
        {
            name = aName;
            id = aID;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
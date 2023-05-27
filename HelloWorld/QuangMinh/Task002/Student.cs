using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task002
{
    public class Student
    {
        public string? name;
        public int id;
        public string major;
        public Student(string aName, int aID, string aMajor)
        {
            name = aName;
            id = aID;
            major = aMajor;
        }
    }
}
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task002
{
    public class Student
    {
        public string name;
        public int year;
        public string major;
        public string graduate;
        public string status;
        public Student(string sname,int syear,string smajor,string sgraduate,string sstatus) 
        {
            name = sname;
            year = syear;
            major = smajor;
            graduate = sgraduate;
            status = sstatus;
        }
    }
}
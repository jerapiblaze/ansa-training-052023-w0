
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
//using System.Text;
//using System.Threading.Tasks;

namespace Task002.Types
{
    public class Student 
    {
        public string Name {get;set;}
        public int id {get; set;}
        public double Score{get; set;}

        public Student(int id, string name, double score)
        {
            this.id = id;
            this.Name=name;
            this.Score=score;  
        }
    }
}
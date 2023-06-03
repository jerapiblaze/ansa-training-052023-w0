using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace MvcStudent.Models{
    public class Student{
        [Key]
        public int id {get; set;}
        public string? name {get; set;}

        public double GPA {get; set;}
    }
}
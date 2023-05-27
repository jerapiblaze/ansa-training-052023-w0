using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Task02x.Core.DTOs;
using Task02x.Utils;

namespace Task02x.Core.Models;

public class Student {
    [Key]
    public int Id {set; get;}

    public string? Name {set; get;}

    public string? Secret {set; get;}

    public double Point {set; get;}
    public Student(StudentRequestDTO student){
        Name = student.Name;
        Point = student.Point;
        Secret = RandomString.GenerateString(10, true, true, true);
    }
    [JsonConstructor]
    public Student(int Id = 0, string Name = "", string Secret = "", double Point = 0){
        this.Id = Id;
        this.Name = Name;
        this.Secret = Secret;
        this.Point = Point;
    }
}
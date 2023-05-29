using Task02x.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Task02x.Core.DTOs;
public class StudentRequestDTO
{
    public string? Name { set; get; }
    public double Point { set; get; }
    public StudentRequestDTO(Student student){
        Name = student.Name;
        Point = student.Point;
    }
    [JsonConstructor]
    public StudentRequestDTO(string Name, double Point){
        this.Name = Name;
        this.Point = Point;
    }
}
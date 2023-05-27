using Task02x.Core.Models;
namespace Task02x.Core.DTOs;
public class StudentResponseDTO
{
    public int Id { set; get; }

    public string? Name { set; get; }

    public double Point { set; get; }
    public StudentResponseDTO(Student student){
        Id = student.Id;
        Name = student.Name;
        Point = student.Point;
    }
}
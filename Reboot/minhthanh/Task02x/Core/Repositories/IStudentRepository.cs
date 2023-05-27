using System;
using System.Collections.Generic;
using System.Linq;
using Task02x.Core.Models;
using Task02x.Core.DTOs;

namespace Task02x.Core.Repositories;

public interface IStudentRepository {
    IEnumerable<Student>? GetStudents();
    IEnumerable<Student>? GetStudentsByName(string name);
    Student? GetStudentById(int Id);
    Student? DeleteStudentById(int Id);
    Student? UpdateStudentById(int Id, Student student);
    Student AddStudent(Student student);
    IEnumerable<Student> AddStudents(IEnumerable<Student> students);
}
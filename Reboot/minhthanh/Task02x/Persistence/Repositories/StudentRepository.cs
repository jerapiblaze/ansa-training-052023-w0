using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Task02x.Core.Models;
using Task02x.Core.Repositories;

namespace Task02x.Persistence.Repositories;

public class StudentRepository : IStudentRepository {
    private readonly AppicationDbContext _context;
    public StudentRepository(AppicationDbContext context){
        _context = context;
    }
    public IEnumerable<Student>? GetStudents(){
        return _context.Students.ToList();
    }
    public IEnumerable<Student>? GetStudentsByName(string name)
    {
        return _context.Students.Where(s => s.Name.ToLower().Contains(name)).ToList();
    }
    public Student? GetStudentById(int Id){
        return _context.Students.Find(Id);
    }
    public Student? DeleteStudentById(int Id)
    {
        var oldStudent = _context.Students.Find(Id);
        if (oldStudent == null)
        {
            return null;
        }
        _context.Students.Remove(oldStudent);
        return oldStudent;
    }
    public Student? UpdateStudentById(int Id, Student student){
        var oldStudent = _context.Students.Find(Id);
        if (oldStudent == null){
            return null;
        }
        _context.Entry(oldStudent).State = EntityState.Modified;
        oldStudent.Name = student.Name;
        oldStudent.Point = student.Point;
        return student;
    }
    public IEnumerable<Student> AddStudents(IEnumerable<Student> students){
        _context.Students.AddRange(students);
        return students;
    }
    public Student AddStudent(Student student)
    {
        _context.Students.Add(student);
        return student;
    }
}
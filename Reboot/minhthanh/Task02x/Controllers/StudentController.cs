using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore;

using Task02x.Core;
using Task02x.Core.DTOs;
using Task02x.Core.Models;
using Task02x.Persistence;

namespace Task02x.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentController : Controller
{
    private readonly IOperation _operation;
    public StudentController(IOperation operation){
        _operation = operation;
    }

    [HttpGet]
    public IResult Index(){
        var students = _operation.Students.GetStudents();
        if (students == null){
            return Results.NoContent();
        }
        List<StudentResponseDTO> studentsDTO = students.Select(s => new StudentResponseDTO(s)).ToList();
        return Results.Ok(studentsDTO);
    }
    [HttpGet("{id}")]
    public IResult GetStudentById(int id){
        var student = _operation.Students.GetStudentById(id);
        if (student == null){
            return Results.NotFound();
        }
        var studentDTO = new StudentResponseDTO(student);
        return Results.Ok(studentDTO);
    }
    [HttpGet("search/name={name}")]
    public IResult GetStudentsByName(string name){
        var students = _operation.Students.GetStudentsByName(name);
        if (students == null)
        {
            return Results.NoContent();
        }
        List<StudentResponseDTO> studentsDTO = students.Select(s => new StudentResponseDTO(s)).ToList();
        return Results.Ok(studentsDTO);
    }
    [HttpPost]
    public IResult AddStudents(List<StudentRequestDTO> studentsDTO){
        List<Student> students = studentsDTO.Select(s => new Student(s)).ToList();
        _operation.Students.AddStudents(students);
        try {
            _operation.Complete();
        }
        catch (Exception e) {
            return Results.Problem(e.ToString());
        }if (students == null)
        {
            return Results.Ok();
        }

        return Results.Ok(studentsDTO);
    }
    [HttpDelete("{id}")]
    public IResult DeleteStudentById(int id){
        var student = _operation.Students.DeleteStudentById(id);
        if (student == null){
            return Results.NotFound();
        }
        try
        {
            _operation.Complete();
        }
        catch (Exception e)
        {
            return Results.Problem(e.ToString());
        }
        var studentDTO = new StudentResponseDTO(student);
        return Results.Ok(studentDTO);
    }
    [HttpPut("{id}")]
    public IResult UpdateStudentById(int id, StudentRequestDTO studentDTO){
        var student = new Student(studentDTO);
        _operation.Students.UpdateStudentById(id, student);
        try
        {
            _operation.Complete();
        }
        catch (Exception e)
        {
            return Results.Problem(e.ToString());
        }
        student = _operation.Students.GetStudentById(id);
        if (student == null){
            return Results.Problem();
        }
        var studentResDTO = new StudentResponseDTO(student);
        return Results.Ok(studentResDTO);
    }
}
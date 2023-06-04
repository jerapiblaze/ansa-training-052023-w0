using Microsoft.AspNetCore.Mvc;
using MvcStudent.Data;
using System.Text.Encodings.Web;
using MvcStudent.Models;

namespace MvcStudent.Controllers;

[Route("[controller]")]
public class StudentController : Controller
{
    // 
    private readonly MvcStudentContext _context;

    public StudentController(MvcStudentContext context)
    {
        _context = context;
    }
    [HttpGet("/")]
    public IResult GetHelloWorld(){
        return Results.Ok("Hello another world");
    }
    [HttpGet("{id}")]
    public IResult Get([FromRoute]int id) {
        return Results.Ok(_context.Student.Find(id));
    }
    [HttpGet]
    public IResult GetAll(){
        return Results.Ok(_context.Student.ToList());
    }
    // public IResult Get(string name)
    //     => Results.Ok(_context.Student.ToList().Where(x => x.name == name));
    [HttpPost]
    public IResult Post([FromBody]List<Student> Students){
        _context.Student.AddRange(Students);
        _context.SaveChanges();
        return Results.Ok(Students);
    }
    [HttpPut("{id}")]
    public IResult Put([FromRoute]int id, [FromBody]Student stu){
        var old = _context.Student.Find(id);
        if (old == null){
            return Results.NotFound();
        }
        _context.Student.Remove(old);
        _context.Student.Add(stu);
        _context.SaveChanges();
        return Results.Ok(stu);
    } 
    [HttpDelete("{id}")]
    public IResult Delete([FromRoute]int id){
        var sv = _context.Student.Find(id);
        if(sv == null){
            return Results.NotFound();
        }
        _context.Student.Remove(sv);
        _context.SaveChanges();
        return Results.Ok(sv);
    }
}
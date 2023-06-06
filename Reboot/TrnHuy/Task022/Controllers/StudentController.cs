using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC2.Models;
using MVC2.Repository;

namespace MVC2.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        public ListStudents list = new ListStudents(); 

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("hello")]
        public IActionResult Hello()
        {
            return Content("Hello");
        }
        [HttpGet("{id}")]
        public IResult View([FromQuery]int id)
        {
            Student? student = list.FindById(id);
            if(student == null)
                return Results.NotFound();
            return Results.Ok(@$"{student.ToString()}");
        }
        [HttpGet]
        public string ViewAll()
        {
            //return $@"{list.WriteByJSON()}";
            return list.GetAllToString();
        }
        [HttpPost]
        public void Post([FromBody]List<Student> students)
        {
            list.AddList(students);
            list.UpdateToDB();
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            list.DeleteById(id);
            list.UpdateToDB();
        }

        [HttpPut("{id}/{newName}")]
        public void change([FromQuery]int id, [FromQuery]string newName)
        {
            Student find = list.FindById(id);
            find.Name = newName;
            list.UpdateToDB();
        }
    }
}
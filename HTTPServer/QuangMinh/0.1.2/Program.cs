using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Http;


namespace _0._1._2;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        List<Student> students = new List<Student>();
        students.Add(new Student{name="Minh", id=20214010});
        students.Add(new Student{name="MLH", id=20213962});
        students.Add(new Student{name="Tung", id=20214032});
        students.Add(new Student{name="Dat", id=20210321});
        
        
        app.MapGet("/", () => "Hello World!");

        // app.MapGet("/", () => "Hello another world!");

        app.MapGet("/students", () => {return students;});

        app.MapGet("/students/{id}", (int id) => 
        {
            return students.FindAll(s => s.id == id);
        });

        app.MapPost("/students", async (HttpContext context) =>
        {
            // Read the request body
            var requestBody = await context.Request.BodyReader.ReadAsync();
            var studentJson = requestBody.Buffer.FirstSpan.ToArray();
            
            // Deserialize the JSON into a Student object
            var newStudent = JsonSerializer.Deserialize<Student>(studentJson);

            // Add the new student to the list
            students.Add(newStudent);

            // Return a response with the added student
            context.Response.StatusCode = (int)HttpStatusCode.Created;
            await context.Response.WriteAsync(newStudent.ToString());
        });

        app.MapPut("/students/{id}", async (HttpContext context) =>
        {
            var id = int.Parse(context.Request.RouteValues["id"].ToString());
            //Read the request body
            var requestBody = await context.Request.BodyReader.ReadAsync();
            var studentJson = requestBody.Buffer.FirstSpan.ToArray();
            
            var updatedStudent = JsonSerializer.Deserialize<Student>(studentJson);

            var existingStudent = students.Find(s => s.id == id);
            if (existingStudent != null)
            {
                existingStudent.name = updatedStudent.name;
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync(JsonSerializer.Serialize(existingStudent));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        });

        app.MapDelete("/students/{id}", async (HttpContext context) =>
        {
            var id = int.Parse(context.Request.RouteValues["id"].ToString());

            var studentToRemove = students.Find(s => s.id == id);
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
        });

        app.Run();
    }
}

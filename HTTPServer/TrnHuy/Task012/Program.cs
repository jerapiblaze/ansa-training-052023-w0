using System.Security.Principal;
using System.Reflection.Metadata;
using System.Collections.Generic;
using HTTPServer02.Entities;
using HTTPServer02.Repository;
using Microsoft.AspNetCore.Mvc;
using HTTPServer02.DTOs;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(_ => { _.SwaggerEndpoint("/swagger/v1/swagger.json", "API docs"); });
// danh sach hoc sinh -> list

ListStudent list = new ListStudent();

Student hs1 = new Student(1, "A", 9.5);
Student hs2 = new Student(2, "B", 8.5);
Student hs3 = new Student(3, "C", 7.5);
Student hs4 = new Student(4, "D", 6.5);

list.Add(hs1);
list.Add(hs2);
list.Add(hs3);
list.Add(hs4);

app.MapGet("/", () => "Hello Another World!").WithMetadata(new SwaggerOperationAttribute("API docs", "description001"));;

app.MapGet("/students/{id?}", (int? id) => {
    if(id == null)
    {
        //List<Student> ds = new List<Student>();
        string ds = list.GetAllToString();
        return ds;
    }
    else
    {
        Student result = list.FindById(id.Value);
        return result.ToString();
    }
}).WithMetadata(new SwaggerOperationAttribute("API docs", "API docs"));;

app.MapPost("/students", (List<Student> ds) => {
    list.Create(ds);
}).WithMetadata(new SwaggerOperationAttribute("API docs", "API docs"));;



app.MapPost("/students/change/{id}", ([FromBody]createdStudentDTO dto ,[FromRoute] int id) => {
    Student find = list.FindById(id);
    find.Name = dto.Name;
}).WithOpenApi();;
app.MapDelete("/students/{id}", (int id) => {
    Student find = list.FindById(id);
    list.Delete(find);
}).WithName("GetWeatherForecast").WithOpenApi();;


app.Run();

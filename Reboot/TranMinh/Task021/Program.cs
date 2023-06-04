using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentContext>(options =>
{
    options.UseSqlServer("YourConnectionString");
});

var app = builder.Build();

app.MapGet("/", () => "Hello another World!");

app.MapGet("/student", (StudentContext context) =>
{
    var studentList = context.Students.ToList();

    string jsonString = JsonSerializer.Serialize(studentList, new JsonSerializerOptions { WriteIndented = true });
    jsonString = jsonString.Replace("},", "},\n");
    return jsonString;
});

app.MapGet("/student/{id}/", (int id, StudentContext context) =>
{
    var selected = context.Students.Find(id);
    if (selected == null)
    {
        return Results.NotFound(id);
    }
    else
    {
        string jsonString = JsonSerializer.Serialize(selected, new JsonSerializerOptions { WriteIndented = true });
        return Results.Text(jsonString);
    }
});

app.MapPost("/students", (List<Student> stus, StudentContext context) =>
{
    context.Students.AddRange(stus);
    context.SaveChanges();
    return Results.Ok(stus);
});

app.MapPut("/students/{id}", (int id, Student stu, StudentContext context) =>
{
    if (id != stu.id)
    {
        return Results.BadRequest("Requested id mismatched with data id");
    }

    var selected = context.Students.Find(id);
    if (selected == null)
    {
        return Results.NotFound("No id found");
    }

    context.Entry(selected).CurrentValues.SetValues(stu);
    context.SaveChanges();

    return Results.Ok(stu);
});

app.MapDelete("/students/{id}", (int id, StudentContext context) =>
{
    var selected = context.Students.Find(id);
    if (selected == null)
    {
        return Results.NotFound("No id found");
    }

    context.Students.Remove(selected);
    context.SaveChanges();

    return Results.Ok(selected);
});

app.Run();

public class Student
{
    public int id { get; set; }
    public string Name { get; set; }
    public double Score { get; set; }

    public Student(int id, string Name, double Score)
    {
        this.id = id;
        this.Name = Name;
        this.Score = Score;
    }
}

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("YourConnectionString");
    }
}

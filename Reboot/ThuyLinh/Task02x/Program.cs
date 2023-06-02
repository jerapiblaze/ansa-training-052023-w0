using Microsoft.EntityFrameworkCore;
using ThuyLinh.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();
app.MapGet("/", async context =>
            
                    await context.Response.WriteAsync("Hello another world"));
app.MapGet("/Student", async (TodoDb db) =>
    await db.Todos.ToListAsync());


app.MapGet("/Student/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id)
        is Todo todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/Student", async (Todo Todo, TodoDb db) =>
{
    db.Todos.Add(Todo);
    await db.SaveChangesAsync();

    return Results.Created($"/Student/{Todo.Id}", Todo);
});

app.MapPut("/Student/{id}", async (int id, Todo inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Name = inputTodo.Name;
    todo.Id = inputTodo.Id;
  

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/Student/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is Todo todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});

app.Run();
app.MapPost("/Student", async (Todo todo, TodoDb db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/Student/{todo.Id}", todo);
});

using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StudentDb>(opt => opt.UseInMemoryDatabase("StudentList"));

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello another world!");

app.MapGet("/student", async (StudentDb db) => await db.Students.Select(x=> new StudentDTO(x)).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, StudentDb db) =>
    await db.Students.FindAsync(id)
        is Student stu
            ? Results.Ok(new StudentDTO(stu))
            : Results.NotFound());
app.MapPost("/student", async(StudentDTO studentDTO, StudentDb db) =>
{
    var sv = new Student
    {
        id = studentDTO.id,
        name = studentDTO.name,
        GPA = studentDTO.GPA
    };
    db.Students.Add(sv);
    await db.SaveChangesAsync();
    return Results.Created($"/student/{sv.id}", new StudentDTO(sv));
});


app.MapPut("/student/{id}", async (StudentDb db, StudentDTO studentDTO, int id) =>
{
      var student = await db.Students.FindAsync(id);
      if (student is null) return Results.NotFound();
      student.name = studentDTO.name;
      student.GPA = studentDTO.GPA;
      await db.SaveChangesAsync();
      return Results.NoContent();
});


app.MapDelete("/student/{id}", async (int id, StudentDb db) =>
{
    if (await db.Students.FindAsync(id) is Student student)
    {
        db.Students.Remove(student);
        await db.SaveChangesAsync();
        return Results.Ok(new StudentDTO(student));
    }

    return Results.NotFound();
});


app.Run();
    public class Student
    {
          public int id { get; set; }
          public string? name { get; set; }
          public double GPA { get; set; }
    }

    public class StudentDTO
{
    public int id {get; set; }
    public string? name { get; set; }
    public double GPA { get; set; }

    public StudentDTO() { }
    public StudentDTO(Student student) =>
    (id, name, GPA) = (student.id, student.name, student.GPA);
}
    class StudentDb : DbContext
{
    public StudentDb(DbContextOptions<StudentDb> options) : base(options) { }
    public DbSet<Student> Students => Set<Student>();
}
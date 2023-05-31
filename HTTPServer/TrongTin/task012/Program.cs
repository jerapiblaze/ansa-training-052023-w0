using Task012;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var studentDb = new List<Student>();
void addStudent(List<Student> DS, Student sv){
    DS.Add(sv);
}

app.MapGet("/", () => "Hello another world");

app.MapGet("/students",() =>{
    return Results.Ok(studentDb);
});

app.MapGet("/students/{id}", (int id) =>{
    Student? selection = studentDb.Find(s => s.ID == id);
    if (selection == null){
        return Results.NotFound(id);
    }
    return Results.Ok(selection);
});

app.MapPost("/students", (Student stu) => {
    addStudent(studentDb, stu);
    return Results.Ok(stu);
});

app.MapPut("/students/{id}", (int ID, Student sv) => {
    if (ID != sv.ID){
        return Results.BadRequest("Mismatch");
    }
    Student? selection = studentDb.Find(s => s.ID == ID);
    if (selection == null){
        return Results.NotFound("No ID found");
    }
    studentDb.Remove(sv);
    studentDb.Add(sv);
    return Results.Ok(sv);
});
app.MapDelete("/students/{id}", (int ID) =>{
     Student? selection = studentDb.Find(s => s.ID == ID);
    if(selection != null){
        studentDb.Remove(selection);
    }
    return Results.Ok(selection);
});


app.Run();

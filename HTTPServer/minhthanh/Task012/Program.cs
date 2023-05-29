using Task012.Types;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var studentList = new List<Student>();

List<Student> generateRandomList(int amount){
    List<Student> lStu = new List<Student>();
    for (int i = 0; i < amount; i++){
        lStu.Add(new Student(i, @$"hell{i}ooooo{amount-i-1}", i*i/10));
    }
    return lStu;
}

app.MapGet("/", () => {
    studentList = generateRandomList(10);
    return Results.Ok("Hello another world");
});

app.MapGet("/students", () => {
    return Results.Ok(studentList);
});

app.MapGet("/students/{id}", (int id) => {
    Student? selected = studentList.Find(s => s.id == id);
    if (selected == null){
        return Results.NotFound(id);
    }
    return Results.Ok(selected);
});

app.MapPost("/students", (List<Student> stus) => {
    studentList.AddRange(stus);
    return Results.Ok(stus);
});

app.MapPut("/students/{id}", (int id, Student stu) => {
    if (id != stu.id){
        return Results.BadRequest("Requested id mismatched with data id");
    }
    Student? selected = studentList.Find(s => s.id == id);
    if (selected == null){
        return Results.NotFound("No id found");
    }
    studentList.Remove(stu);
    studentList.Add(stu);
    return Results.Ok(stu);
});

app.MapDelete("/students/{id}", (int id) => {
    Student? selected = studentList.Find(s => s.id == id);
    if (selected == null)
    {
        return Results.NotFound("No id found");
    }
    studentList.Remove(selected);
    return Results.Ok(selected);
});

app.Run();

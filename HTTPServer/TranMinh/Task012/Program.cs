using Task002.Types;
using System.Text.Json;
using System.Collections.Generic;



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var studentList = new List<Student>();
List<Student> generateRandomList(int num){
    List<Student> List = new List<Student>();
            Random random = new Random();
            string[] Names = { "Minh", "Nam", "Phong", "Linh", "Hue", "Quang", "Nhat", "Khanh", "Thao", "Trung" };
            for (int i = 1; i <= num; i++)
            {
                string Name = Names[random.Next(Names.Length)];
                double score = random.Next(1, 11);

                List.Add(new Student(i, Name, score));
            }
            return List;
}
 studentList = generateRandomList(10);


app.MapGet("/", () => "Hello another World!");


app.MapGet("/student", () => {

            string jsonString1 = JsonSerializer.Serialize(studentList, new JsonSerializerOptions { WriteIndented = true });
            jsonString1 = jsonString1.Replace("},", "},\n");
            return jsonString1;
});

app.MapGet("/student/{id}/", (int id) => {

    Student? selected = studentList.Find(s => s.id == id);
        if (selected == null)
        {
                return Results.NotFound(id);
        }
    else{
        string jsonString = JsonSerializer.Serialize(selected, new JsonSerializerOptions { WriteIndented = true });
        return Results.Text(jsonString);
    }
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

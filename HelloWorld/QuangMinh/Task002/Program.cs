namespace Task002;
class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Minh", 20214010, "ET1");
        Student student2 = new Student("Long", 20202131, "ET3");

        Console.WriteLine(student1.name + "-" + student1.id);
        Console.WriteLine(student2.name + "-" + student2.id);
    }
}

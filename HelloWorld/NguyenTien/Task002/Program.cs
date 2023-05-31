using Task002.Types;

namespace Task002
{
    public class Task002
    {
        public static void Main(string[] args)
        {
            var listStudent = new List<Student>();
            for (int i = 0;i < 10;i++) 
            {
                Student student = new(i , @$"h{9-i}el{i}lo", i * i / 10);
                listStudent.Add(student);  
            }
            foreach (Student student in listStudent)
            {
                Console.WriteLine(student);
            }
        }
    }
}

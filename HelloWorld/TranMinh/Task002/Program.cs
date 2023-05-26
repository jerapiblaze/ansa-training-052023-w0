
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using Task002.Types;

namespace Task002
{

    public class Program
    {
        public static void Main()
        {
            StudentList studentList = new StudentList();
            studentList.InitData(10);

            Console.WriteLine("\nStudent List");
            string jsonString1 = JsonSerializer.Serialize(studentList.GetStudents(), new JsonSerializerOptions { WriteIndented = true });
            jsonString1 = jsonString1.Replace("},", "},\n");
            Console.WriteLine(jsonString1);
        }
    }
}
    

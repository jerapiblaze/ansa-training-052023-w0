using System.Data.Common;
using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MVC2.Models;
using MVC2.Repository.Common;
using Newtonsoft.Json;

namespace MVC2.Repository
{
    public class ListStudents : RepositoryBase<Student>, IListStudents
    {
        public Student? FindById(int id)
        {
            foreach(var item in dataSource)
            {
                if(item.Id == id)
                    return item;
            }
            return null;
        }

        public string GetAllToString()
        {
            string result = "";
            foreach(var item in dataSource)
            {
                result += @$"{item.Id} - {item.Name} - {item.Point}
                ";
            }
            return result;
        }
        public void DeleteById(int id)
        {
            foreach(var item in dataSource)
            {
                if(item.Id == id)
                    dataSource.Remove(item);
            }
        }
        // public ListStudents()
        // {
        //     dataSource.Add(new Student(1, "A", 9.5));
        //     dataSource.Add(new Student(2, "B", 8.5));
        //     dataSource.Add(new Student(3, "C", 7.5));
        // }
        public void UpdateToDB()
        {
            string sqlConnection = "Data Source = localhost,1433; Initial Catalog  = BlueLime; User ID = sa; Password=Password123";
            var connection = new SqlConnection(sqlConnection);
            
            connection.Open();

            using DbCommand command = new SqlCommand();
            command.Connection = connection;

            foreach(var item in dataSource)
            {
                var id = new SqlParameter("@ID", item.Id);
                var name = new SqlParameter("@Name", item.Name);
                var point = new SqlParameter("@Point", item.Point); 
                command.Parameters.Add(id);
                command.Parameters.Add(name);
                command.Parameters.Add(point);

                command.CommandText = "INSERT INTO dbo.Student(Id, Name, Point) VALUES (@ID , @Name, @Point)";

                command.ExecuteNonQuery();

                command.Parameters.Clear();
            }
            connection.Close();
        }

        public string WriteByJSON()
        {
            string result = "";
            foreach(var item in dataSource)
            {
                result += JsonConvert.SerializeObject(item);
                result += @"
                ";
            }
            return result;
        }
    }
}
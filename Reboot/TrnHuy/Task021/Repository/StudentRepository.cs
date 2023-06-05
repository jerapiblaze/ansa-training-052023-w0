using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDB.Entities;
using WebDB.Repository.Common;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace WebDB.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
 
        public StudentRepository()
        {
           
        }

        public string WriteByJson(List<Student> students)
        {
            string result = "";
            foreach(var item in students)
            {
                result += JsonConvert.SerializeObject(item);
                result += @"
                ";
            }
            return result;
        }

        public void UpdateToDataBase()
        {
            string sqlConnection = "Data Source = localhost,1433; Initial Catalog  = BlueLime; User ID = sa; Password=Password123";
            var _connection = new SqlConnection(sqlConnection);
            _connection.Open();  
            var transaction = _connection.BeginTransaction();
            try{
            using DbCommand command = new SqlCommand();
          
            command.Connection = _connection;

            foreach(var item in DataSource)
            {
                var id = new SqlParameter("@ID", item.Id);
                var name = new SqlParameter("@Name", item.Name);
                var point = new SqlParameter("@Point", item.Point); 
                command.Parameters.Add(id);
                command.Parameters.Add(name);
                command.Parameters.Add(point);

                command.CommandText = "INSERT INTO dbo.Students(Id, Name, Point) VALUES (@ID , @Name, @Point)";

                command.ExecuteNonQuery();

                command.Parameters.Clear();
                transaction.Commit();
            }
            }
            catch{
                transaction.Rollback();
            }
            _connection.Close();
        }
    }
}
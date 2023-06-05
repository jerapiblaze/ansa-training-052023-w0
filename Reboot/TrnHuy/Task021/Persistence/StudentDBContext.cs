using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebDB.Entities;
using Newtonsoft.Json;


namespace WebDB.Persistence
{
    public class ProductDBContext : DbContext
    {
        private string stringConnection = File.ReadAllText("/home/trn_huyy/C#/WebDB/stringConnection.json");
        public List<Product> listproduct  {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = localhost,1433; Initial Catalog  = BlueLime; User ID = sa; Password=Password123");


        }

        public void UPdateToDB()
        {
        
            string sqlConnection = "Data Source = localhost,1433; Initial Catalog  = BlueLime; User ID = sa; Password=Password123";
            using var connection = new SqlConnection(sqlConnection);

            var adapter = new SqlDataAdapter();
            adapter.TableMappings.Add("Table", "Product");

            //adapter.SelectCommand("INSERT INTO dbo.NewTable(Id, Name, Price, Brand) VALUES (@ID , @Name, @Price, @Brand)",connection);
        }
    }
}
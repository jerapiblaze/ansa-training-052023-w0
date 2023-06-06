using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVC2.DataBase
{
    public class StudentDB : DbContext
    {
        private string stringConnection = File.ReadAllText("/home/trn_huyy/C#/MVC2/stringConnection.json");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Dsata Source = localhost,1433; Initial Catalog  = BlueLime; User ID = sa; Password=Password123");
        }
    }
}
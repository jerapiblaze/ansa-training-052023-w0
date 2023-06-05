using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC2.Models;
using MVC2.Repository.Common;

namespace MVC2.Repository
{
    public interface IListStudents : IRepositoryBase<Student>
    {
        string GetAllToString();
        Student? FindById(int id); 
        void DeleteById(int id);
        void UpdateToDB();
        string WriteByJSON();
    }
}
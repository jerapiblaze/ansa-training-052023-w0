using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTTPServer02.Repository.Common;
using HTTPServer02.Entities;


namespace HTTPServer02.Repository
{
    public interface IListStudentRepository : IRepositoryBase<Student>
    {
        string GetAllToString();
        Student FindById(int id);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTTPServer02.Repository.Common;
using HTTPServer02.Entities;

namespace HTTPServer02.Repository
{
    public class ListStudent : RepositoryBase<Student>, IListStudentRepository
    {
        public string GetAllToString()
        {
            string result= "";
            foreach(var item in dataSource)
            {
                result += @$"{item.Id} - {item.Name} - {item.Point}";
            }
            return result;
        }
        public Student FindById(int id)
        {
            var find = dataSource.Find((Student item) => 
                item.Id == id)
            ;
            if(find != null)
            {
                return find;
            }
            throw new Exception ("Not Found");
        }
    }
}
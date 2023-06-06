using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Repository.Common
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        public List<T> dataSource = new List<T>();
        public void Add(T entity)
        {
            Console.WriteLine("Add");
            Console.WriteLine(entity);
            dataSource.Add(entity);
            Console.WriteLine(dataSource);
        }

        public void AddList(List<T> newList)
        {
            Console.WriteLine("Add range");
            Console.WriteLine(newList);
            dataSource.AddRange(newList);
            Console.WriteLine(dataSource);
        }

        public void Delete(T entity)
        {
            Console.WriteLine("Delete");
            Console.WriteLine(entity);
            dataSource.Remove(entity);
            Console.WriteLine(dataSource);
        }

        public List<T> GetAll()
        {
            Console.WriteLine("Get All");
            Console.WriteLine(dataSource);
            return dataSource;
        }
    }
}
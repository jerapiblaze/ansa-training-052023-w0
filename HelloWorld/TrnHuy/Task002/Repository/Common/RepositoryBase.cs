using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld02.Repository.Common
{
    public class RepositoryBase <T> : IRepository <T>
    {
        public List<T> dataSource = new List<T>();
        public void Create(List<T> newList)
        {
            dataSource = newList;
        }
        public void Add(T entities)
        {
            dataSource.Add(entities);
        }
        public List<T> GetAll()
        {
            return dataSource;
        }

        public void Delete(T entities)
        {
            dataSource.Remove(entities);
        }
    }
}
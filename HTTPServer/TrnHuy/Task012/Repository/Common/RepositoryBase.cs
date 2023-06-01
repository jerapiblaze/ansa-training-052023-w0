using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPServer02.Repository.Common
{
    public class RepositoryBase <T> : IRepositoryBase <T>
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
        public void Delete(T entity)
        {
            dataSource.Remove(entity);
        }
        public List<T> GetAll()
        {
            return dataSource;
        }

    }
}
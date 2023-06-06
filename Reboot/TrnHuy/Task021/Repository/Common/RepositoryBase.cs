using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDB.Entities;

namespace WebDB.Repository.Common
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        public List<T> DataSource = new List<T>();
        
        public List<T> FindById(Func<T,bool> condition)
        {
            return DataSource.Where(condition).ToList();
        }

        public void Create(List<T> list)
        {
            DataSource = list;
        }

        public int Count()
        {
            return DataSource.Count;
        }

        public T Add(T entity)
        {
            DataSource.Add(entity);
            return entity;
        }

        // public T Delete(T entity)
        // {
        //     foreach(var item in DataSource)
        //     {
        //         if(equal)
        //             DataSource.Remove(item);
        //     }
        //     throw new NotImplementedException();
        // }

        public List<T> GetAll()
        {
            return DataSource;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Repository.Common
{
    public interface IRepositoryBase<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void AddList(List<T> newList); 
    }
}
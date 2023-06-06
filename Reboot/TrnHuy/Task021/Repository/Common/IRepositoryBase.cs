using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDB.Repository.Common
{
    public interface IRepositoryBase <T>
    {
        List<T> GetAll();
        T Add(T entity);
        void Create(List<T> list);
        //T Delete(T entity);
        List<T> FindById(Func<T, bool> condition);

        int Count();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HTTPServer02.Repository.Common
{
    public interface IRepositoryBase <T>
    {
        List<T> GetAll();
        void Add(T entities);
        void Create(List<T> newList);
        void Delete(T entities);
    }
}
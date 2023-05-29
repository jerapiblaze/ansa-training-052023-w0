using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld02.Repository.Common
{
    public interface IRepository <T>
    {
        List<T> GetAll();
        void Add(T entities);
        void Create(List<T> newList);
        void Delete(T entities);
    }
}
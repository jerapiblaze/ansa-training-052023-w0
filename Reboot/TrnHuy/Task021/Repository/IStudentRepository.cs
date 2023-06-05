using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDB.Entities;
using WebDB.Repository.Common;

namespace WebDB.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        string WriteByJson(List<Product> product);

        void UpdateToDataBase();
    }
}
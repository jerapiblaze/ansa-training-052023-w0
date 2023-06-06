using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDB.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name {get; set;}
        public decimal Price {get; set;}
        public string Brand {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDB.Entities
{
    public class BaseEntity<K>
    {
        public K Id {get; set;}
    }
}
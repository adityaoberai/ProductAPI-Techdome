using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class ProductType
    {
        public Int32 id { get; set; }
        public string name { get; set; }
        public bool canBeInsured { get; set; }
    }
}

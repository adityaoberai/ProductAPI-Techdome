using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Product
    {
        public Int32 id { get; set; }
        public string name { get; set; }
        public double salesPrice { get; set; }
        public Int32 productTypeId { get; set; }
    }
}

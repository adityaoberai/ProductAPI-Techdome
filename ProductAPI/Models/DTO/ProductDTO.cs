using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class ProductDTO
    {
        [JsonPropertyName("id")]
        public Int32 Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("salesPrice")]
        public double salesPrice { get; set; }
        [JsonPropertyName("productTypeId")]
        public Int32 productTypeId { get; set; }
    }
}

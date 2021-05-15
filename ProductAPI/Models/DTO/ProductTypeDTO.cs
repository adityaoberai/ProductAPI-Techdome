using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class ProductTypeDTO
    {
        [JsonPropertyName("id")]
        public Int32 Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("canBeInsured")]
        public bool canBeInsured { get; set; }
    }
}

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

        public ProductType DTOToProductType(ProductTypeDTO productType)
        {
            return new ProductType()
            {
                id = productType.Id,
                name = productType.Name,
                canBeInsured = productType.canBeInsured
            };
        }

        public ProductTypeDTO ProductTypeToDTO(ProductType productType)
        {
            return new ProductTypeDTO()
            {
                Id = productType.id,
                Name = productType.name,
                canBeInsured = productType.canBeInsured
            };
        }
    }
}

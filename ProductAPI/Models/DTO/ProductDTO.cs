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

        public Product DTOToProduct(ProductDTO product)
        {
            return new Product()
            {
                id = product.Id,
                name = product.Name,
                salesPrice = product.salesPrice,
                productTypeId = product.productTypeId
            };
        }

        public ProductDTO ProductToDTO(Product product)
        {
            return new ProductDTO()
            {
                Id = product.id,
                Name = product.name,
                salesPrice = product.salesPrice,
                productTypeId = product.productTypeId
            };
        }
    }
}

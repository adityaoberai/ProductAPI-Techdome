using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductAPI.Data;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("insurance")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly ProductContext _productContext;
        private readonly ProductTypeContext _productTypeContext;

        public InsuranceController(ProductContext productContext, ProductTypeContext productTypeContext)
        {
            _productContext = productContext;
            _productTypeContext = productTypeContext;
        }
        
        // POST /insurance
        [HttpPost]
        public async Task<ActionResult<double>> PostInsurance([FromBody]ProductIds productIds)
        {
            List<int> ids = productIds.Ids;
            double totalInsurance = 0.0;
            int countOfCameras = 0;

            foreach (int id in ids)
            {
                var amount = await GetProductInsurance(id);
                totalInsurance += amount.insurance;
                if (amount.isCamera == true)
                {
                    countOfCameras++;
                }
            }

            if (countOfCameras > 0)
            {
                totalInsurance += 500;
            }

            return Ok(new { insurance = totalInsurance });    
        }

        public async Task<InsuranceAmount> GetProductInsurance(int id)
        {
            var product = ProductToDTO(await _productContext.Products.FindAsync(id));
            var productType = ProductTypeToDTO(await _productTypeContext.ProductTypes.FindAsync(product.productTypeId));

            var amount = new InsuranceAmount { insurance = 0, isCamera = false };

            if (product == null)
            {
                return amount;
            }

            if(product.salesPrice < 500 || productType.canBeInsured == false)
            {
                amount.insurance += 0;
            }
            else if(product.salesPrice < 2000)
            {
                amount.insurance += 1000;
            }
            else
            {
                amount.insurance += 2000;
            }

            if(productType.Name.Equals("laptop") || productType.Name.Equals("smartphone"))
            {
                amount.insurance += 500;
            }

            if(productType.Name.Equals("digital camera"))
            {
                amount.isCamera = true;
            }

            return amount;
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

    public class InsuranceAmount
    {
        public double insurance { get; set; }
        public bool isCamera { get; set; }
    }

    public class ProductIds
    {
        [JsonPropertyName("ids")]
        public List<int> Ids { get; set; }
    }
}

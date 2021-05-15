using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("/product_types")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly ProductTypeContext _context;

        public ProductTypesController(ProductTypeContext context)
        {
            _context = context;
        }

        // GET: /product_types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeDTO>>> GetProductTypes()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            var productTypesDTO = new List<ProductTypeDTO>();
            foreach(ProductType productType in productTypes)
            {
                productTypesDTO.Add(ProductTypeToDTO(productType));
            }
            return productTypesDTO;
        }

        // GET: /product_types/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeDTO>> GetProductType(int id)
        {
            var productType = ProductTypeToDTO(await _context.ProductTypes.FindAsync(id));

            if (productType == null)
            {
                return NotFound();
            }

            return productType;
        }

        // PUT: /product_types/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductType(int id, ProductTypeDTO productType)
        {
            productType.Id = id;

            _context.Entry(DTOToProductType(productType)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: /product_types
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTypeDTO>> PostProductType(ProductTypeDTO productType)
        {
            _context.ProductTypes.Add(DTOToProductType(productType));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductType", new { }, productType);
        }

        // DELETE: /product_types
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            var productType = ProductTypeToDTO(await _context.ProductTypes.FindAsync(id));
            if (productType == null)
            {
                return NotFound();
            }

            _context.ProductTypes.Remove(DTOToProductType(productType));
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductTypes.Any(e => e.id == id);
        }

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

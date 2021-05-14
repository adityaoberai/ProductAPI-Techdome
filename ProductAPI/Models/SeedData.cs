using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var productContext = new ProductContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProductContext>>());

            var productTypeContext = new ProductTypeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProductTypeContext>>());

            var problemDetailsContext = new ProblemDetailsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProblemDetailsContext>>());

            if(!productContext.Products.Any())
            {
                productContext.Products.AddRange(
                    new Product
                    {
                        name = "OnePlus Nord",
                        salesPrice = 350,
                        productTypeId = 1
                    },

                    new Product
                    {
                        name = "Microsoft Surface Go 2",
                        salesPrice = 600,
                        productTypeId = 2
                    },

                    new Product
                    {
                        name = "BenQ Monitor",
                        salesPrice = 20000,
                        productTypeId = 3
                    },

                    new Product
                    {
                        name = "Alienware Area 51 M15X",
                        salesPrice = 4000,
                        productTypeId = 2
                    }
                );
                productContext.SaveChanges();
            }

            if (!productTypeContext.ProductTypes.Any())
            {
                productTypeContext.ProductTypes.AddRange(
                    new ProductType
                    {
                        name = "smartphone",
                        canBeInsured = true
                    },

                    new ProductType
                    {
                        name = "laptop",
                        canBeInsured = true
                    },

                    new ProductType
                    {
                        id = 3,
                        name = "display",
                        canBeInsured = true
                    }
                );
                productTypeContext.SaveChanges();
            }

            if (!problemDetailsContext.ProblemDetails.Any())
            {
                problemDetailsContext.ProblemDetails.AddRange(
                    new ProblemDetails
                    {
                        type = "Not Found",
                        title = "Info Not Found",
                        status = 404,
                        detail = "The requested info was not found",
                        instance = $"Instance at {DateTime.Now}"
                    }
                );
                problemDetailsContext.SaveChanges();
            }
        }
    }
}

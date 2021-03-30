using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.SeedData
{
    public class ShopAppDataSeed
    {
        public static async  Task SeedAsync( ShopAppDbContext context ,ILoggerFactory loggerFactory){
            try{
                 if(!context.ProductTypes.Any()){

                     var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                     var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                     foreach (var item in types)
                     {
                         context.ProductTypes.Add(item);
                     }
                    await context.SaveChangesAsync();

                    // await context.ProductTypes.AddAsync(new ProductType{
                    //     Id=1,
                    //     Name="ProductType One",  
                    // });
                    //  await context.ProductTypes.AddAsync(new ProductType{
                    //     Id=2,
                    //     Name="ProductType Two",  
                    // });
                }
                  if(!context.ProductBrands.Any()){

                      var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                      var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                      foreach (var item in brands)
                      {
                          context.ProductBrands.Add(item);
                      }
                      await context.SaveChangesAsync();

                    // await context.ProductBrands.AddAsync(new ProductBrand{
                    //     Id=1,
                    //     Name="ProductBrand One",  
                    // });
                    //  await context.ProductBrands.AddAsync(new ProductBrand{
                    //     Id=2,
                    //     Name="ProductBrand Two",  
                    // });
                }

                if(!context.Products.Any()){


                     var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                      var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                      foreach (var item in products)
                      {
                          context.Products.Add(item);
                      }
                      await context.SaveChangesAsync();
                    // await context.Products.AddAsync(new Product{
                    //     Id=1,
                    //     Name="Product One",
                    //     Description="Description Of Product One",
                    //     Price=15.00m,
                    //     PictureUrl="",
                    //     ProductBrandId=2,
                    //     ProductTypeId=2
                    // });
                    // await context.Products.AddAsync(new Product{
                    //     Id=2,
                    //     Name="Product Two",
                    //     Description="Description Of Product Two",
                    //     Price=17.50m,
                    //     PictureUrl="",
                    //      ProductBrandId=2,
                    //     ProductTypeId=2
                    // });
                }
            }catch(Exception ex){
                var logger = loggerFactory.CreateLogger<ShopAppDataSeed>();
                logger.LogError(ex,"Error Occurred when Seed Data");
            }

        }
    }
}
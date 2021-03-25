using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.Seed
{
    public class SeedData
    {
        public async static void SeedAsync(ShopAppDbContext context ,ILoggerFactory loggerFactory){
            try{
                 if(await context.ProductTypes.AnyAsync()){
                    await context.ProductTypes.AddAsync(new ProductType{
                        Id=1,
                        Name="ProductType One",  
                    });
                     await context.ProductTypes.AddAsync(new ProductType{
                        Id=2,
                        Name="ProductType Two",  
                    });
                }
                  if(await context.ProductBrands.AnyAsync()){
                    await context.ProductBrands.AddAsync(new ProductBrand{
                        Id=1,
                        Name="ProductBrand One",  
                    });
                     await context.ProductBrands.AddAsync(new ProductBrand{
                        Id=2,
                        Name="ProductBrand Two",  
                    });
                }

                if(await context.Products.AnyAsync()){
                    await context.Products.AddAsync(new Product{
                        Id=1,
                        Name="Product One",
                        Description="Description Of Product One",
                        Price=15.00m,
                        PictureUrl="",
                        ProductBrandId=2,
                        ProductTypeId=2
                    });
                    await context.Products.AddAsync(new Product{
                        Id=2,
                        Name="Product Two",
                        Description="Description Of Product Two",
                        Price=17.50m,
                        PictureUrl="",
                         ProductBrandId=2,
                        ProductTypeId=2
                    });
                }
            }catch(Exception ex){
                var logger = loggerFactory.CreateLogger<SeedData>();
                logger.LogInformation(ex,"Error Occurred when Seed Data");
            }

        }
    }
}
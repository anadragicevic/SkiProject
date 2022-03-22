using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class Seed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){

            try{
                
                if(!context.ProductBrands.Any())
                {
                    var brandsData= await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/brands.json");

                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach(var item in brands){
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if(!context.ProductTypes.Any())
                {
                    var typesData= await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/types.json");

                    var types=JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach(var item in types){
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if(!context.Products.Any())
                {
                    var dataa= await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

                    var data=JsonSerializer.Deserialize<List<Product>>(dataa);

                    foreach(var item in data){
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }

            catch(Exception ex){
                var logger=loggerFactory.CreateLogger<Seed>();
                logger.LogError(ex.Message);
            }
        }
        
    }
}

using Domain.Contracts;
using System.Text.Json;

namespace Presistence.Data
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task SeedDataAsync()
        {
            try
            {
                var PendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }
                if (!_dbContext.productBrands.Any())
                {
                    var ProductBrandData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\brands.json");
                    var ProductBrand =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (ProductBrand is not null && ProductBrand.Any())
                    {
                        await _dbContext.productBrands.AddRangeAsync(ProductBrand);
                    }
                }
                if (!_dbContext.productTypes.Any())
                {
                    var ProductTypeData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\types.json");
                    var ProductType = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                    if (ProductType is not null && ProductType.Any())
                    {
                        await _dbContext.productTypes.AddRangeAsync(ProductType);
                    }
                }
                if (!_dbContext.products.Any())
                {
                    var ProductData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\products.json");
                    var Product = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (Product is not null && Product.Any())
                    {
                        await _dbContext.products.AddRangeAsync(Product);
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //handle exc
                
            }
        }
    }
}

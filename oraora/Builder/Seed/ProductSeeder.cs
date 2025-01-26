using Oraora.Models.Seed;
using Oraora.Repository;

namespace Oraora.Builder.Seed;

public static class ProductSeeder
{
    public static async Task<IApplicationBuilder> AddProducts(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var productRepo = scope.ServiceProvider.GetService<IProductRepository>();
        ArgumentNullException.ThrowIfNull(productRepo);

        if ((await productRepo.GetProducts()).ToList().Count == 0)
        {
            foreach (var product in ProductSeeds.Products)
            {
                await productRepo.AddProduct(product);
            }
        }

        return builder;
    }
}

using Oraora.Builder.Services;
using Oraora.Extension;
using Oraora.Models;
using SqlKata;

namespace Oraora.Repository;

public interface IProductRepository
{
    public Task AddProduct(Product product);
    public Task<Product> GetProductById(int id);
    public Task<IEnumerable<Product>> GetProducts();
    public Task DeleteProduct(int id);
}

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(ISqliteConnectionProvider connectionProvider)
        : base(connectionProvider) { }

    public async Task AddProduct(Product product)
    {
        await CreateConnection(async conn =>
        {
            await conn.InsertToDatabase(product, true);
        });
    }

    public async Task DeleteProduct(int id)
    {
        var DeleteProduct_Query = new Query(nameof(Product))
            .Where(nameof(Product.Id), id)
            .AsDelete();
        await CreateConnection(async conn =>
        {
            await conn.ExecuteSqlKataAsync(DeleteProduct_Query);
        });
    }

    public async Task<Product> GetProductById(int id)
    {
        var product = new Product();
        var GetProductById_Query = new Query(nameof(Product)).Where(nameof(Product.Id), id);
        await CreateConnection(async conn =>
        {
            product = await conn.QuerySingleSqlKataAsync<Product>(GetProductById_Query);
        });
        return product;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        IEnumerable<Product> products = new List<Product>();
        var GetAllProduct_Query = new Query(nameof(Product));

        await CreateConnection(async conn =>
        {
            products = await conn.QuerySqlKataAsync<Product>(GetAllProduct_Query);
        });

        return products;
    }
}

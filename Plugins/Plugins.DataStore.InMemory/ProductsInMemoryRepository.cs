using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;
public class ProductsInMemoryRepository : IProductRepository
{
    public Task AddProductAsync(Product product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProductAsync(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetProductByIdAsync(int productId, bool loadCategory = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductsAsync(bool loadCategory = false)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductAsync(int productId, Product product)
    {
        throw new NotImplementedException();
    }
}

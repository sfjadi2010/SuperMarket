using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;
public class ProductsInMemoryRepository : IProductRepository
{
    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public Product? GetProductById(int productId, bool loadCategory = false)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProducts(bool loadCategory = false)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(int productId, Product product)
    {
        throw new NotImplementedException();
    }
}

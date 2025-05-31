using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.DataStorePluginInterfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProductsAsync(bool loadCategory = false);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(int productId, Product product);
    Task<Product?> GetProductByIdAsync(int productId, bool loadCategory = false);
    Task DeleteProductAsync(int productId);
    Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
}

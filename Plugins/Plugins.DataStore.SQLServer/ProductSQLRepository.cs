using Microsoft.EntityFrameworkCore;
using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQLServer;
public class ProductSQLRepository : IProductRepository
{
    private readonly MarketDbContext _marketDbContext;

    public ProductSQLRepository(MarketDbContext marketDbContext)
    {
        _marketDbContext = marketDbContext;
    }

    public async Task AddProductAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        await _marketDbContext.Products.AddAsync(product);
        await _marketDbContext.SaveChangesAsync();

    }

    public async Task DeleteProductAsync(int productId)
    {
        var product = await _marketDbContext.Products.FindAsync(productId);

        if (product is null) return;

        _marketDbContext.Products.Remove(product);
        await _marketDbContext.SaveChangesAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int productId, bool loadCategory = false)
    {
        IQueryable<Product> query = GetProductWithCategoryQuery(loadCategory);

        return await query.FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync(bool loadCategory = false)
    {
        IQueryable<Product> query = GetProductWithCategoryQuery(loadCategory);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        return await _marketDbContext
                .Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();
    }

    public async Task UpdateProductAsync(int productId, Product product)
    {
        var exitingProduct = await _marketDbContext.Products.FindAsync(productId);

        if (exitingProduct is null) return;

        _marketDbContext.Products.Update(exitingProduct);
        await _marketDbContext.SaveChangesAsync();
    }

    private IQueryable<Product> GetProductWithCategoryQuery(bool loadCategory)
    {
        var query = _marketDbContext.Products.AsNoTracking();

        if (loadCategory)
        {
            query = query.Include(x => x.Category);
        }

        return query;
    }
}

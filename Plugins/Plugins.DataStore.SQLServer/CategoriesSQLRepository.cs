using Microsoft.EntityFrameworkCore;
using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQLServer;
public class CategoriesSQLRepository : ICategoryRepository
{
    private readonly MarketDbContext _marketDbContext;

    public CategoriesSQLRepository(MarketDbContext marketDbContext)
    {
        _marketDbContext = marketDbContext;
    }

    public async Task AddCategoryAsync(Category category)
    {
        ArgumentNullException.ThrowIfNull(category, nameof(category));

        await _marketDbContext.Categories.AddAsync(category);
    }

    public async Task DeleteCategoryAsync(int categoryId)
    {
        var category = await _marketDbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

        if (category is null) return;

        _marketDbContext.Categories.Remove(category);
        await _marketDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _marketDbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int categoryId)
    {
        return await _marketDbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task UpdateCategoryAsync(int categoryId, Category category)
    {
        if (categoryId != category.Id) return;

        var existingCategory = await _marketDbContext.Categories.FindAsync(categoryId);
        if (existingCategory is null) return;

        existingCategory.Name = category.Name;
        existingCategory.Description = category.Description;

        _marketDbContext.Update(category);
        await _marketDbContext.SaveChangesAsync();
    }
}

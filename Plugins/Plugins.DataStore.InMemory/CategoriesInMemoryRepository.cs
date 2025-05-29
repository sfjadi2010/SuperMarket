using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;

public class CategoriesInMemoryRepository : ICategoryRepository
{
    private readonly List<Category> _categories = new List<Category>()
    {
        new Category { Id = 1, Name = "Beverages", Description = "Drinks and refreshments" },
        new Category { Id = 2, Name = "Snacks", Description = "Chips, cookies, and other snacks" },
        new Category { Id = 3, Name = "Dairy", Description = "Milk, cheese, and other dairy products" }
    };

    public Task AddCategoryAsync(Category category)
    {
        ArgumentNullException.ThrowIfNull("Category cannot be null.");

        var maxId = _categories.Count > 0 ? _categories.Max(x => x.Id) : 0;
        category.Id = maxId + 1;
        _categories.Add(category);
        return Task.CompletedTask;
    }

    public Task DeleteCategoryAsync(int categoryId)
    {
        _categories.RemoveAll(c => c.Id == categoryId);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return Task.FromResult<IEnumerable<Category>>(_categories);
    }

    public Task<Category?> GetCategoryByIdAsync(int categoryId)
    {
        return Task.FromResult<Category?>(_categories.FirstOrDefault(c => c.Id == categoryId));
    }

    public Task UpdateCategoryAsync(int categoryId, Category category)
    {
        var existingCategory = GetCategoryByIdAsync(categoryId).Result;
        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
        }

        return Task.CompletedTask;
    }
}

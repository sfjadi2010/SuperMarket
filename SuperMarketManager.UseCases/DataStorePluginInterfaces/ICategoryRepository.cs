using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.DataStorePluginInterfaces;
public interface ICategoryRepository
{
    Task AddCategoryAsync(Category category);
    Task DeleteCategoryAsync(int categoryId);
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int categoryId);
    Task UpdateCategoryAsync(int categoryId, Category category);
}

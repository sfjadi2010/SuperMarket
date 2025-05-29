using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace SuperMarketManager.UseCases.CategoryUseCases;
public class AddCategoryUseCase : IAddCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;
    public AddCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void Execute(Category category)
    {
        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category cannot be null.");
        }
        if (string.IsNullOrWhiteSpace(category.Name))
        {
            throw new ArgumentException("Category name cannot be empty.", nameof(category.Name));
        }
        _categoryRepository.AddCategory(category);
    }
}

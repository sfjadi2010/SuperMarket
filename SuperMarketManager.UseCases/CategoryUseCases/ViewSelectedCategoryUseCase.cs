using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace SuperMarketManager.UseCases.CategoryUseCases;
public class ViewSelectedCategoryUseCase : IViewSelectedCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public ViewSelectedCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Category? Execute(int categoryId)
    {
        if (categoryId <= 0)
        {
            throw new ArgumentException("Category ID must be greater than zero.", nameof(categoryId));
        }
        return _categoryRepository.GetCategoryById(categoryId);
    }
}

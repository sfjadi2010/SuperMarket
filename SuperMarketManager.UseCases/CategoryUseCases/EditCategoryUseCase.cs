using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace SuperMarketManager.UseCases.CategoryUseCases;
public class EditCategoryUseCase : IEditCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public EditCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void Execute(int categoryId, Category category)
    {
        _categoryRepository.UpdateCategory(categoryId, category);
    }
}

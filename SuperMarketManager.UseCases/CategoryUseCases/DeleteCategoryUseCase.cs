using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace SuperMarketManager.UseCases.CategoryUseCases;
public class DeleteCategoryUseCase : IDeleteCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;
    public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void Execute(int categoryId)
    {
        if (categoryId <= 0)
        {
            throw new ArgumentException("Category ID must be greater than zero.", nameof(categoryId));
        }
        _categoryRepository.DeleteCategory(categoryId);
    }
}

using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IEditCategoryUseCase
{
    Task ExecuteAsync(int categoryId, Category category);
}
using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IEditCategoryUseCase
{
    Task Execute(int categoryId, Category category);
}
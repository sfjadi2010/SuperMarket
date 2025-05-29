using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IEditCategoryUseCase
{
    void Execute(int categoryId, Category category);
}
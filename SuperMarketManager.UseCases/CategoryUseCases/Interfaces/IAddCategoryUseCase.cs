using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IAddCategoryUseCase
{
    void Execute(Category category);
}
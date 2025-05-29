using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IAddCategoryUseCase
{
    Task Execute(Category category);
}
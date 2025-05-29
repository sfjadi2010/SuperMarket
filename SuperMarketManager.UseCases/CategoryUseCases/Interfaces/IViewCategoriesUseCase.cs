using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IViewCategoriesUseCase
{
    IEnumerable<Category> Execute();
}
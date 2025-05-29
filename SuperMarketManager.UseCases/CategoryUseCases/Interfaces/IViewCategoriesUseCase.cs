using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IViewCategoriesUseCase
{
    Task<IEnumerable<Category>> Execute();
}
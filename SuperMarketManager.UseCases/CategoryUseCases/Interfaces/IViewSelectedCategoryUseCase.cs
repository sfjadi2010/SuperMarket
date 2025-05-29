using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IViewSelectedCategoryUseCase
{
    Task<Category?> Execute(int categoryId);
}
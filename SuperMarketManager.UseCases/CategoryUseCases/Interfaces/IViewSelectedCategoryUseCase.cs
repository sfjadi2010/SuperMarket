using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
public interface IViewSelectedCategoryUseCase
{
    Category? Execute(int categoryId);
}
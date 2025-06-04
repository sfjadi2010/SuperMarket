using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;

public interface IViewProductsUseCase
{
    Task<IEnumerable<Product>> ExecuteAsync(bool loadCategories = false);
}
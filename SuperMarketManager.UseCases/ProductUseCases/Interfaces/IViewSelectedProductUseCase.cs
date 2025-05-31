using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;
public interface IViewSelectedProductUseCase
{
    Task<Product> Execute(int productId);
}
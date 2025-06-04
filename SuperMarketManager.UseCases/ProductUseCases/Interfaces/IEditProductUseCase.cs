using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;
public interface IEditProductUseCase
{
    Task ExecuteAsync(int productId, Product product);
}
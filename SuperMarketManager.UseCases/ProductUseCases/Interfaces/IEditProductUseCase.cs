using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;
public interface IEditProductUseCase
{
    Task Execute(int productId, Product product);
}
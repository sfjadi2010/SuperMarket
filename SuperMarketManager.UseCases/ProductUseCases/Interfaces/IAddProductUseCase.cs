using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;

public interface IAddProductUseCase
{
    Task Execute(Product product);
}
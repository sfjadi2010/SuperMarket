namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;

public interface IDeleteProductUseCase
{
    Task Execute(int productId);
}
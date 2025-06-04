namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;

public interface IDeleteProductUseCase
{
    Task ExecuteAsync(int productId);
}
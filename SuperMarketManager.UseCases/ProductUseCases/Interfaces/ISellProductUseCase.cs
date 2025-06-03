namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;

public interface ISellProductUseCase
{
    Task ExecuteAsync(string cashireName, int productId, int qtyToSell);
}
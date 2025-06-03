namespace SuperMarketManager.UseCases.TransactionUseCases.Interfaces;
public interface IAddTransactionUseCase
{
    Task ExecuteAsync(string cashierName, int productId, string productName, double price, int BeforeQty, int soldQty);
}
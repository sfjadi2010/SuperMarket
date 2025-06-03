namespace SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

public interface IRecordTransactionUseCase
{
    Task ExecuteAsync(string cashierName, int productId, int qtySell);
}
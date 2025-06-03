using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.TransactionUseCases.Interfaces;
public interface ISearchTransactionUseCase
{
    Task<IEnumerable<Transaction>> ExecuteAsync(string cashierName, DateTime startDate, DateTime endDate);
}
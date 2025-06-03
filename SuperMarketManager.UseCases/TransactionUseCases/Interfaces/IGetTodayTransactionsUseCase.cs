using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.TransactionUseCases.Interfaces;
public interface IGetTodayTransactionsUseCase
{
    Task<IEnumerable<Transaction>> ExecuteAsync(string cashierName);
}
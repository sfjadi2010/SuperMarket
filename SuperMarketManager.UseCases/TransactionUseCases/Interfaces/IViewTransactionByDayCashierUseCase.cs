using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.TransactionUseCases.Interfaces;
public interface IViewTransactionByDayCashierUseCase
{
    Task<IEnumerable<Transaction>> ExecuteAsync(string cashierName, DateTime date);
}
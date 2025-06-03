using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

namespace SuperMarketManager.UseCases.TransactionUseCases;
public class ViewTransactionByDayCashierUseCase : IViewTransactionByDayCashierUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public ViewTransactionByDayCashierUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>> ExecuteAsync(string cashierName, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
        {
            throw new ArgumentException("Cashier name cannot be null or empty.", nameof(cashierName));
        }

        return await _transactionRepository.GetByDayAndCashierAsync(cashierName, date);
    }
}

using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

namespace SuperMarketManager.UseCases.TransactionUseCases;
public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTodayTransactionsUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>> ExecuteAsync(string cashierName)
    {
        ArgumentNullException.ThrowIfNull(cashierName, nameof(cashierName));

        var transactions = await _transactionRepository.GetByDayAndCashierAsync(cashierName, DateTime.Now);
        return transactions ?? new List<Transaction>();
    }
}

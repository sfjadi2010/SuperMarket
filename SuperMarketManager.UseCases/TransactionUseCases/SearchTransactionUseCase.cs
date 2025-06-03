using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

namespace SuperMarketManager.UseCases.TransactionUseCases;
public class SearchTransactionUseCase : ISearchTransactionUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public SearchTransactionUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>> ExecuteAsync(string cashierName, DateTime startDate, DateTime endDate)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(cashierName, nameof(cashierName));

        return await _transactionRepository.SearchAsync(cashierName, startDate, endDate);
    }
}

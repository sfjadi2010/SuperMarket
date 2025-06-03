using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

namespace SuperMarketManager.UseCases.TransactionUseCases;
public class ViewSearchUseCase : IViewSearchUseCase
{
    private readonly ITransactionRepository _transactionRepository;
    public ViewSearchUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<IEnumerable<Transaction>> ExecuteAsync(string cashierName, DateTime startDate, DateTime endDate)
    {
        if (string.IsNullOrWhiteSpace(cashierName))
        {
            throw new ArgumentException("Cashier name cannot be null or empty.", nameof(cashierName));
        }
        if (startDate > endDate)
        {
            throw new ArgumentException("Start date cannot be later than end date.");
        }
        return await _transactionRepository.SearchAsync(cashierName, startDate, endDate);
    }
}

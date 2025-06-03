using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

namespace SuperMarketManager.UseCases.TransactionUseCases;
public class AddTransactionUseCase : IAddTransactionUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public AddTransactionUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task ExecuteAsync(string cashierName, int productId, string productName, double price, int BeforeQty, int soldQty)
    {
        await _transactionRepository.AddAsync(cashierName, productId, productName, price, BeforeQty, soldQty);
    }
}

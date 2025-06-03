using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

namespace SuperMarketManager.UseCases.TransactionUseCases;
public class RecordTransactionUseCase : IRecordTransactionUseCase
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IProductRepository _productRepository;

    public RecordTransactionUseCase(ITransactionRepository transactionRepository, IProductRepository productRepository)
    {
        _transactionRepository = transactionRepository;
        _productRepository = productRepository;
    }

    public async Task ExecuteAsync(string cashierName, int productId, int qtySell)
    {
        Product? product = await _productRepository.GetProductByIdAsync(productId);

        if (product is not null)
        {
            await _transactionRepository.AddAsync(
                cashierName,
                productId,
                product.Name,
                product.Price.HasValue ? product.Price.Value : 0,
                product.Quantity.HasValue ? product.Quantity.Value : 0,
                qtySell);
        }
    }
}

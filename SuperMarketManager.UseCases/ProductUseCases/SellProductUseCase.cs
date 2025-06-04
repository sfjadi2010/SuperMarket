using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.ProductUseCases.Interfaces;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;

namespace SuperMarketManager.UseCases.ProductUseCases;
public class SellProductUseCase : ISellProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IRecordTransactionUseCase _recordTransactionUseCase;

    public SellProductUseCase(IProductRepository productRepository, IRecordTransactionUseCase recordTransactionUseCase)
    {
        _productRepository = productRepository;
        _recordTransactionUseCase = recordTransactionUseCase;
    }

    public async Task ExecuteAsync(string cashireName, int productId, int qtyToSell)
    {
        Product? product = await _productRepository.GetProductByIdAsync(productId);

        if (product is null) return;

        await _recordTransactionUseCase.ExecuteAsync(cashireName, productId, qtyToSell);

        product.Quantity -= qtyToSell;
        await _productRepository.UpdateProductAsync(productId, product);
    }
}

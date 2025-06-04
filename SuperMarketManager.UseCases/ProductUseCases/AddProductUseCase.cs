using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.ProductUseCases.Interfaces;

namespace SuperMarketManager.UseCases.ProductUseCases;
public class AddProductUseCase : IAddProductUseCase
{
    private readonly IProductRepository _productRepository;
    public AddProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task ExecuteAsync(Product product)
    {
        ArgumentNullException.ThrowIfNull(product, nameof(product));

        await _productRepository.AddProductAsync(product);
    }
}

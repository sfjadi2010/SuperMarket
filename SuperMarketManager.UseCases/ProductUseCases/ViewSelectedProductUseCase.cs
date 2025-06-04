using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.ProductUseCases.Interfaces;

namespace SuperMarketManager.UseCases.ProductUseCases;
public class ViewSelectedProductUseCase : IViewSelectedProductUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewSelectedProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> ExecuteAsync(int productId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId, true);

        if (product == null)
        {
            throw new InvalidOperationException($"Product with ID {productId} not found.");
        }

        return product;
    }
}

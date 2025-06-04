using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.ProductUseCases.Interfaces;

namespace SuperMarketManager.UseCases.ProductUseCases;
public class ViewProductsUseCase : IViewProductsUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductsUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> ExecuteAsync(bool loadCategories = false)
    {
        // Placeholder implementation
        return await _productRepository.GetProductsAsync(loadCategories);
    }
}

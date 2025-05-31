using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;
using SuperMarketManager.UseCases.ProductUseCases.Interfaces;

namespace SuperMarketManager.UseCases.ProductUseCases;
public class ViewProductsByCategoryIdUseCase : IViewProductsByCategoryIdUseCase
{
    private readonly IProductRepository _productRepository;

    public ViewProductsByCategoryIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Execute(int? categoryId)
    {
        return await _productRepository.GetProductsByCategoryIdAsync(categoryId ?? 0);
    }
}

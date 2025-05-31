using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.ProductUseCases.Interfaces;
public interface IViewProductsByCategoryIdUseCase
{
    Task<IEnumerable<Product>> Execute(int? categoryId);
}
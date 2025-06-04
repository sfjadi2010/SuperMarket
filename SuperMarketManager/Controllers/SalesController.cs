using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
using SuperMarketManager.UseCases.ProductUseCases.Interfaces;
using SuperMarketManager.ViewModels;

namespace SuperMarketManager.Controllers;
public class SalesController : Controller
{
    private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
    private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;
    private readonly ISellProductUseCase _sellProductUseCase;
    private readonly IViewProductsByCategoryIdUseCase _viewProductsByCategoryIdUseCase;

    public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,
        IViewSelectedProductUseCase viewSelectedProductUseCase,
        ISellProductUseCase sellProductUseCase,
        IViewProductsByCategoryIdUseCase viewProductsByCategoryIdUseCase)
    {
        _viewCategoriesUseCase = viewCategoriesUseCase;
        _viewSelectedProductUseCase = viewSelectedProductUseCase;
        _sellProductUseCase = sellProductUseCase;
        _viewProductsByCategoryIdUseCase = viewProductsByCategoryIdUseCase;
    }

    public async Task<IActionResult> Index()
    {
        var salesViewModel = new SalesViewModel
        {
            Categories = await _viewCategoriesUseCase.ExecuteAsync(),
        };

        return View(salesViewModel);
    }

    public async Task<IActionResult> SellProductPartial(int productId)
    {
        Product? product = await _viewSelectedProductUseCase.ExecuteAsync(productId);
        if (product is null)
        {
            return NotFound();
        }
        return PartialView("_SellProduct", product);
    }

    [HttpPost]
    public async Task<IActionResult> SellProduct(SalesViewModel salesViewModel)
    {
        Product product = await _viewSelectedProductUseCase.ExecuteAsync(salesViewModel.SelectedProductId);
        salesViewModel.SelectedCategoryId = (product?.CategoryId is not null) ? product.CategoryId.Value : 0;
        salesViewModel.Categories = await _viewCategoriesUseCase.ExecuteAsync();

        if (ModelState.IsValid)
        {
            if (product is not null)
            {
                await _sellProductUseCase.ExecuteAsync(
                    "cashier-1",
                    salesViewModel.SelectedProductId,
                    salesViewModel.QuantityToSell);
            }
        }

        return View(nameof(Index), salesViewModel);
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.UseCases.CategoryUseCases.Interfaces;
using SuperMarketManager.UseCases.ProductUseCases.Interfaces;
using SuperMarketManager.ViewModels;

namespace SuperMarketManager.Controllers;

[Authorize(Policy = "Inventory")]
public class ProductsController : Controller
{
    private readonly IViewProductsUseCase _viewProductsUseCase;
    private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;
    private readonly IAddProductUseCase _addProductUseCase;
    private readonly IEditProductUseCase _editProductUseCase;
    private readonly IDeleteProductUseCase _deleteProductUseCase;

    private readonly IViewCategoriesUseCase _viewCategoriesUseCase;

    public ProductsController(
        IViewProductsUseCase viewProductsUseCase,
        IViewSelectedProductUseCase viewSelectedProductUseCase,
        IViewProductsByCategoryIdUseCase viewProductsByCategoryIdUseCase,
        IAddProductUseCase addProductUseCase,
        IEditProductUseCase editProductUseCase,
        IDeleteProductUseCase deleteProductUseCase,
        IViewCategoriesUseCase viewCategoriesUseCase)
    {
        _viewProductsUseCase = viewProductsUseCase;
        _viewSelectedProductUseCase = viewSelectedProductUseCase;
        _addProductUseCase = addProductUseCase;
        _editProductUseCase = editProductUseCase;
        _deleteProductUseCase = deleteProductUseCase;
        _viewCategoriesUseCase = viewCategoriesUseCase;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _viewProductsUseCase.ExecuteAsync(true);

        return View(products);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Action = "create";
        var productViewModel = new ProductViewModel();
        var categories = await _viewCategoriesUseCase.ExecuteAsync();
        productViewModel.Categories = categories.ToList();
        return View(productViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            await _addProductUseCase.ExecuteAsync(productViewModel.Product);
            return RedirectToAction(nameof(Index));
        }

        return View(productViewModel);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        ArgumentNullException.ThrowIfNull(id, nameof(id));

        ViewBag.Action = "edit";

        var product = await _viewSelectedProductUseCase.ExecuteAsync(id.Value);
        var categories = await _viewCategoriesUseCase.ExecuteAsync();

        if (product is null)
        {
            return NotFound();
        }

        var productViewModel = new ProductViewModel
        {
            Product = product,
            Categories = categories.ToList()
        };

        return View(productViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            await _editProductUseCase.ExecuteAsync(productViewModel.Product.Id, productViewModel.Product);

            return RedirectToAction(nameof(Index));
        }

        return View(productViewModel);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        await _deleteProductUseCase.ExecuteAsync(id ?? 0);
        return RedirectToAction(nameof(Index));
    }
}

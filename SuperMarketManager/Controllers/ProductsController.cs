using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.Models;
using SuperMarketManager.ViewModels;

namespace SuperMarketManager.Controllers;
public class ProductsController : Controller
{
    public IActionResult Index()
    {
        var products = ProductsRepository.GetProducts(true);

        return View(products);
    }

    public IActionResult Create()
    {
        ViewBag.Action = "create";
        var productViewModel = new ProductViewModel();
        //productViewModel.Categories = CategoriesRepository.GetCategories();
        return View(productViewModel);
    }

    [HttpPost]
    public IActionResult Create(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            ProductsRepository.AddProduct(productViewModel.Product);
            return RedirectToAction(nameof(Index));
        }

        //productViewModel.Categories = CategoriesRepository.GetCategories();

        return View(productViewModel);
    }

    public IActionResult Edit(int? id)
    {
        ViewBag.Action = "edit";
        var product = ProductsRepository.GetProductById(id ?? 0);
        if (product is null)
        {
            return NotFound();
        }

        var productViewModel = new ProductViewModel
        {
            Product = product,
            //Categories = CategoriesRepository.GetCategories()
        };

        return View(productViewModel);
    }

    [HttpPost]
    public IActionResult Edit(ProductViewModel productViewModel)
    {
        if (ModelState.IsValid)
        {
            ProductsRepository.UpdateProduct(productViewModel.Product.Id, productViewModel.Product);
            return RedirectToAction(nameof(Index));
        }

        //productViewModel.Categories = CategoriesRepository.GetCategories();
        return View(productViewModel);
    }

    public IActionResult Delete(int? id)
    {
        ProductsRepository.DeleteProduct(id ?? 0);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult ProductsByCategoryPartial(int categoryId)
    {
        var products = ProductsRepository.GetProductsByCategoryId(categoryId);

        return PartialView("_Products", products);
    }
}

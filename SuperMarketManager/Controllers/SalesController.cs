using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.Models;
using SuperMarketManager.ViewModels;

namespace SuperMarketManager.Controllers;
public class SalesController : Controller
{
    public IActionResult Index()
    {
        var salesViewModel = new SalesViewModel
        {
            Categories = CategoriesRepository.GetCategories()
        };

        return View(salesViewModel);
    }

    public IActionResult SellProductPartial(int productId)
    {
        var product = ProductsRepository.GetProductById(productId);
        if (product is null)
        {
            return NotFound();
        }
        return PartialView("_SellProduct", product);
    }
}

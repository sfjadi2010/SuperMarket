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
}

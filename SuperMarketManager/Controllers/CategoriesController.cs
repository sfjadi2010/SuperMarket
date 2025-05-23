using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.Models;

namespace SuperMarketManager.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var category = new Category { Id = id.HasValue ? id.Value : 0 };

            return View(category);
        }
    }
}

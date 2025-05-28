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

    [HttpPost]
    public IActionResult SellProduct(SalesViewModel salesViewModel)
    {
        var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
        salesViewModel.SelectedCategoryId = (product?.CategoryId is not null) ? product.CategoryId.Value : 0;
        salesViewModel.Categories = CategoriesRepository.GetCategories();

        if (ModelState.IsValid)
        {
            if (product is not null)
            {
                int beforeQty = product.Quantity ?? 0;
                int afterQty = Math.Max(0, beforeQty - salesViewModel.QuantityToSell);
                int soldQty = salesViewModel.QuantityToSell;

                var transaction = new Transaction
                {
                    CashierName = "Cashier-1",
                    ProductId = product.Id,
                    ProductName = product.Name ?? string.Empty,
                    Price = product.Price,
                    BeforeQty = beforeQty,
                    AfterQty = afterQty,
                    SoldQty = soldQty
                };

                TransactionsRepository.Add(transaction);

                product.Quantity -= salesViewModel.QuantityToSell;
                ProductsRepository.UpdateProduct(salesViewModel.SelectedProductId, product);
            }
        }

        return View(nameof(Index), salesViewModel);
    }
}

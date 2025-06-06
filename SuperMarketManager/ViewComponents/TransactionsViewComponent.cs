using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.Models;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace SuperMarketManager.ViewComponents;

[ViewComponent]
public class TransactionsViewComponent : ViewComponent
{
    private readonly ITransactionRepository _transactionRepository;
    public TransactionsViewComponent(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync(string userName)
    {
        var transactions = await _transactionRepository.GetByDayAndCashierAsync(userName, DateTime.Now);
        return View(transactions);
    }
}

using Microsoft.AspNetCore.Mvc;
using SuperMarketManager.UseCases.TransactionUseCases.Interfaces;
using SuperMarketManager.ViewModels;

namespace SuperMarketManager.Controllers;
public class TransactionsController : Controller
{
    private readonly ISearchTransactionUseCase _searchTransactionUseCase;

    public TransactionsController(ISearchTransactionUseCase searchTransactionUseCase)
    {
        _searchTransactionUseCase = searchTransactionUseCase;
    }

    public IActionResult Index()
    {
        TransactionsViewModel transactionsViewModel = new TransactionsViewModel();

        return View(transactionsViewModel);
    }

    public async Task<IActionResult> Search(TransactionsViewModel transactionsViewModel)
    {
        var transactions = await _searchTransactionUseCase.ExecuteAsync(
            transactionsViewModel.CashierName ?? string.Empty,
            transactionsViewModel.StartDate,
            transactionsViewModel.EndDate);

        transactionsViewModel.Transactions = transactions;

        return View("Index", transactionsViewModel);
    }
}

using SuperMarketManager.CoreBusiness;
using System.ComponentModel.DataAnnotations;

namespace SuperMarketManager.ViewModels;

public class TransactionsViewModel
{
    [Display(Name = "Cashier Name")]
    public string CashierName { get; set; } = default!;

    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; } = DateTime.Today;

    public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
}

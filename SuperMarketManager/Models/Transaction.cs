namespace SuperMarketManager.Models;

public class Transaction
{
    public int Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = default!;
    public double? Price { get; set; }
    public int? BeforeQty { get; set; }
    public int? AfterQty { get; set; }
    public string CashirName { get; set; } = default!;
}

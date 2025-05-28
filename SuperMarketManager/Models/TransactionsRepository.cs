namespace SuperMarketManager.Models;

public class TransactionsRepository
{
    private static List<Transaction> _transactions = new List<Transaction>();
    public static IEnumerable<Transaction> GetTransactions()
    {
        return _transactions;
    }

    public static IEnumerable<Transaction> GetByDayAndCashier(string username, DateTime dateTime)
    {
        // Compare only the Date part
        var transactions = _transactions.Where(t => t.CashierName == username && t.TimeStamp.Date == dateTime.Date).ToList();
        return transactions;
    }

    public static void Add(Transaction transaction)
    {
        if (transaction is not null)
        {
            transaction.Id = _transactions.Count + 1; // Simple ID generation
            transaction.TimeStamp = DateTime.Now;
            _transactions.Add(transaction);
        }
    }
    public static void Clear()
    {
        _transactions.Clear();
    }

    internal static IEnumerable<Transaction> Search(string username, DateTime startDate, DateTime endDate)
    {
        // Compare only the Date part for the range
        return _transactions
            .Where(t => t.CashierName == username && t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date)
            .ToList();
    }
}

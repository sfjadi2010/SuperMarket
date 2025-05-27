namespace SuperMarketManager.Models;

public class TransactionsRepository
{
    private static List<Transaction> _transactions = new List<Transaction>();
    public static IEnumerable<Transaction> GetTransactions()
    {
        return _transactions;
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
}

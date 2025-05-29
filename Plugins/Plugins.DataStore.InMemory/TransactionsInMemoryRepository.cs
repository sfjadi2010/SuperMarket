using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory;
public class TransactionsInMemoryRepository : ITransactionRepository
{
    public void Add(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByDayAndCashier(string cashierName, DateTime date)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime dateTime)
    {
        throw new NotImplementedException();
    }
}

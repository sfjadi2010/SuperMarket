using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQLServer;
public class TransactionSQLRepository : ITransactionRepository
{
    public Task AddAsync(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transaction>> GetByDayAndCashierAsync(string cashierName, DateTime date)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Transaction>> SearchAsync(string cashierName, DateTime startDate, DateTime dateTime)
    {
        throw new NotImplementedException();
    }
}

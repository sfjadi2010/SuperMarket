using SuperMarketManager.CoreBusiness;

namespace SuperMarketManager.UseCases.DataStorePluginInterfaces;
public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetByDayAndCashierAsync(string cashierName, DateTime date);
    Task<IEnumerable<Transaction>> SearchAsync(string cashierName, DateTime startDate, DateTime dateTime);
    Task AddAsync(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty);
}

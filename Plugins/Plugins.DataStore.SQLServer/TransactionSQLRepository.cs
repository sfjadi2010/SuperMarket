using Microsoft.EntityFrameworkCore;
using SuperMarketManager.CoreBusiness;
using SuperMarketManager.UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQLServer;
public class TransactionSQLRepository : ITransactionRepository
{
    private readonly MarketDbContext _marketDbContext;

    public TransactionSQLRepository(MarketDbContext marketDbContext)
    {
        _marketDbContext = marketDbContext;
    }

    public async Task AddAsync(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
    {
        var transaction = new Transaction()
        {
            TimeStamp = DateTime.Now,
            CashierName = cashierName,
            ProductId = productId,
            ProductName = productName,
            Price = price,
            BeforeQty = beforeQty,
            SoldQty = soldQty
        };

        _marketDbContext.Transactions.Add(transaction);
        await _marketDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByDayAndCashierAsync(string cashierName, DateTime date)
    {
        var query = BuildCashierNameQuery(cashierName);

        query = query.Where(t => t.TimeStamp.Date == date.Date);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> SearchAsync(string cashierName, DateTime startDate, DateTime endDate)
    {
        var query = BuildCashierNameQuery(cashierName);

        query = query.Where(t => t.TimeStamp.Date >= startDate.Date && t.TimeStamp.Date <= endDate.Date);

        return await query.ToListAsync();
    }

    private IQueryable<Transaction> BuildCashierNameQuery(string cashierName)
    {
        var query = _marketDbContext.Transactions.AsNoTracking().AsQueryable();
        if (!string.IsNullOrWhiteSpace(cashierName))
        {
            query = query.Where(t => t.CashierName == cashierName);
        }

        return query;
    }
}

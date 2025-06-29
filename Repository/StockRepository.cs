using Microsoft.EntityFrameworkCore;

namespace DMobileSite.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Stock?> GetStockByMobileId(int mobileId) 
            => await _context.Stocks.FirstOrDefaultAsync(s => s.MobileId == mobileId);

        public async Task ManageStock(StockDTO stockToManage)
        {
            // if there is no stock for given book id, then add new record
            // if there is already stock for given book id, update stock's quantity
            var existingStock = await GetStockByMobileId(stockToManage.MobileId);
            if (existingStock is null)
            {
                var stock = new Stock { MobileId = stockToManage.MobileId, Quantity = stockToManage.Quantity };
                _context.Stocks.Add(stock);
            }
            else
            {
                existingStock.Quantity = stockToManage.Quantity;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "")
        {
            var stocks = await (from mobile in _context.Mobiles
                                join stock in _context.Stocks
                                on mobile.Id equals stock.MobileId
                                into mobile_stock
                                from mobileStock in mobile_stock.DefaultIfEmpty()
                                where string.IsNullOrWhiteSpace(sTerm) ||
                                mobile.MobileName.ToLower().Contains(sTerm.ToLower())
                                select new StockDisplayModel
                                {
                                    MobileId = mobile.Id,
                                    MobileName = mobile.MobileName,
                                    Quantity = mobileStock == null ? 0 : mobileStock.Quantity
                                }
                                ).ToListAsync();
            return stocks;
        }

    }

    public interface IStockRepository
    {
        Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "");
        Task<Stock?> GetStockByMobileId(int mobileId);
        Task ManageStock(StockDTO stockToManage);
    }
}

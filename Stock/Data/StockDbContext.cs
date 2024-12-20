using Microsoft.EntityFrameworkCore;

namespace FinShark.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

        public DbSet<Stock> Stocks { get; set; }
    }

    public class Stock
    {
        
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public decimal MarketCap { get; set; }
    }
}

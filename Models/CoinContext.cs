using Microsoft.EntityFrameworkCore;

namespace CoinValueApplication.models
{
    public class CoinContext : DbContext
    {
        public CoinContext(DbContextOptions<CoinContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Coin> Coins { get; set; }
    }
}

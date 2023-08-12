using CoinValueApplication.models;
using Microsoft.EntityFrameworkCore;

namespace CoinValueApplication.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        public readonly CoinContext _context;
        public CoinRepository(CoinContext context)
        {
            _context = context;
        }
        public async Task<Coin> Create(Coin coin)
        {
            _context.Coins.Add(coin);
            await _context.SaveChangesAsync();
            return coin;
        }

        public async Task Delete(int id)
        {
            var coinToDelete = await _context.Coins.FindAsync(id);
            _context.Coins.Remove(coinToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Coin>> Get()
        {
            return await _context.Coins.ToListAsync();
        }

        public async Task<Coin> Get(int id)
        {
            return await _context.Coins.FindAsync(id);
        }

        public async Task Update(Coin coin)
        {
            _context.Entry(coin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

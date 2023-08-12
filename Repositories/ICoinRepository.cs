using CoinValueApplication.models;

namespace CoinValueApplication.Repositories
{
    public interface ICoinRepository
    {
        Task<IEnumerable<Coin>> Get();

        Task<Coin> Get(int Id);
        Task<Coin> Create(Coin coin);
        Task Update(Coin coin);
        Task Delete(int Id);
    }
}

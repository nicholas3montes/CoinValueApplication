using CoinValueApplication.models;
using CoinValueApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoinValueApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly ICoinRepository _coinRepository;
        public CoinController(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Coin>> GetCoins()
        {
            return await _coinRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Coin>> GetCoin(int id)
        {
            return await _coinRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Coin>> PostCoin([FromBody] Coin coin)
        {
            var newCoin = await _coinRepository.Create(coin);
            return CreatedAtAction(nameof(GetCoin), new { id = newCoin.Id}, newCoin);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Coin>> Delete(int id)
        {
            var coinToDelete = await _coinRepository.Get(id);

            if (coinToDelete == null)
                return NotFound();
            await _coinRepository.Delete(coinToDelete.Id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutCoin(int id, [FromBody] Coin coin)
        {
            if (id != coin.Id)
                return BadRequest();

            await _coinRepository.Update(coin);
            return  NoContent();
        }
    }
}

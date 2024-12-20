using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Finshark.Dto.Stock;

namespace Stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private static readonly List<StocksDto> Stocks = new List<StocksDto>();


        [HttpPost]
        public IActionResult AddStock([FromBody] StocksDto stock)
        {
            if (stock.MarketCap > 1_000_000)
            {
                return BadRequest(new { message = "Market cap cannot exceed 1 million." });
            }

            if (Stocks.Any(s => s.Symbol == stock.Symbol))
            {
                return BadRequest(new { message = "Stock with the same symbol already exists" });
            }

            Stocks.Add(stock);
            return Ok(new { message = "Stock added successfully.", stock });


        }

        [HttpGet]
        public IActionResult GetStocks()
        {
            return Ok(Stocks);
        }
    }
}

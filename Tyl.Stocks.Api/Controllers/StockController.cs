namespace Tyl.Stocks.Controllers;

using Microsoft.AspNetCore.Mvc;
using Tyl.Stocks.Api.Services;
using Tyle.Stocks.Core.Models;

[ApiController]
[Route("api/stock")]
public class StockController : ControllerBase
{
    private readonly ILogger<StockController> _logger;
    private readonly IStockService _stockService;

    public StockController(
        ILogger<StockController> logger,
        IStockService stockService
        )
    {
        _logger = logger;
        _stockService = stockService;
    }

    [HttpGet]
    [Route("{ticker}")]
    public async Task<Stock> GetStock(string ticker)
    {
        return await _stockService.GetStock(ticker);
    }

    [HttpGet]
    [Route("list")]
    public async Task<IEnumerable<Stock>> List()
    {
        return await _stockService.List();
    }

    [HttpPost]
    [Route("listrange")]
    public async Task<IEnumerable<Stock>> List(string[] tickers)
    {
        return await _stockService.ListRange(tickers);
    }
}

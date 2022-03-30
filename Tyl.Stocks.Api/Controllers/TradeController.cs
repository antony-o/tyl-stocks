namespace Tyl.Stocks.Controllers;

using Microsoft.AspNetCore.Mvc;
using Tyl.Stocks.Api.Services;
using Tyle.Stocks.Core.Models;

[ApiController]
[Route("api/trade")]
public class TradeController : ControllerBase
{
    private readonly ILogger<StockController> _logger;
    private readonly ITradeService _tradeService;

    public TradeController(
        ILogger<StockController> logger,
        ITradeService tradeService
        )
    {
        _logger = logger;
        _tradeService = tradeService;
    }

    [HttpPost]
    [Route("")]
    public async Task<bool> Trade(Trade trade)
    {
        return await _tradeService.AddTrade(trade);
    }
}

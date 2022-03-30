namespace Tyl.Stocks.Api.Repositories;

using Tyle.Stocks.Core.Models;

public class TradeRepository : ITradeRepository
{
    private readonly HashSet<Trade> _trades = new HashSet<Trade>(new TradeComparer());

    public async Task<bool> AddTradeAsync(Trade trade)
    {
        var success = _trades.Add(trade);
        return await Task.FromResult(success);
    }
}

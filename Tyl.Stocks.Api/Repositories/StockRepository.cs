namespace Tyl.Stocks.Api.Repositories;

using System.Linq;
using Tyle.Stocks.Core.Models;

public class StockRepository : IStockRepository
{
    private readonly List<Stock> _stocks = new List<Stock> {
        new Stock { Ticker = "SMB", MarketValue = 10.00m, Timestamp = DateTime.UtcNow },
        new Stock { Ticker = "XRS", MarketValue = 20.00m, Timestamp = DateTime.UtcNow },
        new Stock { Ticker = "ABC", MarketValue = 30.00m, Timestamp = DateTime.UtcNow }
    };

    public async Task<Stock> GetByIdAsync(string ticker)
    {
        return await Task.FromResult(_stocks.FirstOrDefault(stock => string.Equals(stock.Ticker, ticker, StringComparison.OrdinalIgnoreCase))) ?? null;
    }

    public async Task<IEnumerable<Stock>> ListAsync()
    {
        return await Task.FromResult(_stocks);
    }

    public async Task<IEnumerable<Stock>> ListAsync(string[] tickers)
    {
        return await Task.FromResult(_stocks.Where(stock => tickers.Contains(stock.Ticker)));
    }

    public async Task<Stock> UpdateMarketValueAsync(string ticker, decimal newMarketValue)
    {
        var stock = await GetByIdAsync(ticker);
        stock.MarketValue = newMarketValue;

        return stock;
    }
}

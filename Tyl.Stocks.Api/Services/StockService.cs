namespace Tyl.Stocks.Api.Services;

using Tyl.Stocks.Api.Repositories;
using Tyle.Stocks.Core.Exceptions;
using Tyle.Stocks.Core.Models;

public class StockService : IStockService
{
    private readonly IStockRepository _stockRepository;

    public StockService(
        IStockRepository stockRepository
        )
    {
        _stockRepository = stockRepository;
    }

    public async Task<Stock> GetStock(string ticker)
    {
        var stock = await _stockRepository.GetByIdAsync(ticker);

        if (stock == null)
        {
            throw new EntityNotFoundException();
        }

        return stock;
    }
    public async Task<Stock> UpdateMarketValueAsync(string ticker, decimal marketValue)
    {
        var stock = await _stockRepository.UpdateMarketValueAsync(ticker, marketValue);
        return stock;
    }

    public async Task<IEnumerable<Stock>> List()
    {
        return await _stockRepository.ListAsync();
    }

    public async Task<IEnumerable<Stock>> ListRange(string[] tickers)
    {
        return await _stockRepository.ListAsync(tickers);
    }
}

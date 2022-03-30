namespace Tyl.Stocks.Api.Repositories;

using System.Collections.Generic;
using Tyle.Stocks.Core.Models;

public interface IStockRepository
{
    public Task<Stock> GetByIdAsync(string ticker);
    public Task<IEnumerable<Stock>> ListAsync();
    public Task<IEnumerable<Stock>> ListAsync(string[] tickers);
    public Task<Stock> UpdateMarketValueAsync(string ticker, decimal newMarketValue);
}
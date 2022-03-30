namespace Tyl.Stocks.Api.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Tyle.Stocks.Core.Models;

public interface IStockService
{
    Task<Stock> GetStock(string ticker);
    Task<IEnumerable<Stock>> List();
    Task<IEnumerable<Stock>> ListRange(string[] tickers);
    Task<Stock> UpdateMarketValueAsync(string ticker, decimal marketValue);

}
namespace Tyl.Stocks.Api.Repositories;

using Tyle.Stocks.Core.Models;

public interface ITradeRepository
{
    public Task<bool> AddTradeAsync(Trade trade);
}
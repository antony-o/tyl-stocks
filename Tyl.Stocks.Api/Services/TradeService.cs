namespace Tyl.Stocks.Api.Services;

using Tyl.Stocks.Api.Repositories;
using Tyle.Stocks.Core.Models;

public class TradeService : ITradeService
{
    private readonly IStockRepository _stockRepository;
    private readonly ITradeRepository _tradeRepository;

    public TradeService(
        IStockRepository stockRepository,
        ITradeRepository tradeRepository
        )
    {
        _stockRepository = stockRepository;
        _tradeRepository = tradeRepository;
    }

    public async Task<bool> AddTrade(Trade trade)
    {
        // Would need to be in a transaction to ensure both trade and stock market value are updated as an atomic action
        var success = await _tradeRepository.AddTradeAsync(trade);

        // Code to calculate new share price based on trade however that's done
        // a simple algorithm is used below for the test, another service might be needed for this operation.
        decimal newMarketValue = trade.Price / trade.NumOfShares;

        if (success)
        {
            await _stockRepository.UpdateMarketValueAsync(trade.Ticker, newMarketValue);
        }

        return success;
    }
}

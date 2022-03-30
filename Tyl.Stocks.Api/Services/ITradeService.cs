namespace Tyl.Stocks.Api.Services;

using System.Threading.Tasks;
using Tyle.Stocks.Core.Models;

public interface ITradeService
{
    Task<bool> AddTrade(Trade trade);
}
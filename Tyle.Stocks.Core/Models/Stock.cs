namespace Tyle.Stocks.Core.Models;

public class Stock
{
    public string Ticker { get; set; }
    public decimal MarketValue { get; set; }
    public DateTime Timestamp { get; set; }
}

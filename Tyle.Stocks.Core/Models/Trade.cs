namespace Tyle.Stocks.Core.Models;

public class Trade
{
    public string IdempotencyId { get; set; }
    public string Ticker { get; set; }
    public decimal NumOfShares { get; set; }
    public decimal Price { get; set; }
    public int BrokerId { get; set; }
    public DateTime Timestamp { get; set; }
}

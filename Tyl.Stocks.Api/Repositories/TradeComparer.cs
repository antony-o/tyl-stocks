namespace Tyl.Stocks.Api.Repositories;

using System.Diagnostics.CodeAnalysis;
using Tyle.Stocks.Core.Models;

public class TradeComparer : IEqualityComparer<Trade>
{
    public bool Equals(Trade? x, Trade? y)
    {
        if (x == null && y == null)
            return true;
        else if (x == null || y == null)
            return false;

        return x.IdempotencyId.Equals(y.IdempotencyId, StringComparison.InvariantCultureIgnoreCase);
    }

    public int GetHashCode([DisallowNull] Trade obj)
    {
        return obj.IdempotencyId.GetHashCode();
    }
}

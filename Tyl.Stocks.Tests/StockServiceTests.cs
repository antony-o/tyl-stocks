namespace Tyl.Stocks.Tests;

using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Tyl.Stocks.Api.Repositories;
using Tyl.Stocks.Api.Services;
using Tyle.Stocks.Core.Exceptions;
using Tyle.Stocks.Core.Models;

public class Tests
{
    private IStockService _stockService;

    [SetUp]
    public void Setup()
    {
        var mockStockRepository = Mock.Of<IStockRepository>();

        Mock.Get(mockStockRepository).Setup(repo => repo.GetByIdAsync("SMB"))
            .ReturnsAsync(new Stock() { Ticker = "SMB", MarketValue = 5.25m });

        _stockService = new StockService(mockStockRepository);
    }

    [Test]
    public async Task GetStock_Ok()
    {
        // Act
        var result = await _stockService.GetStock("SMB");

        // Assert
        Assert.That(result.Ticker == "SMB");
    }

    [TestCase(null)]
    [TestCase("XYZ")]

    public void GetStock_ShouldThrowNotFoundExceptionIfNull(string ticker)
    {
        //Assert
        var result = Assert.ThrowsAsync<EntityNotFoundException>(() => _stockService.GetStock(ticker));
    }
}
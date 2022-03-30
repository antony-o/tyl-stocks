namespace Tyl.Stocks;

using Tyl.Stocks.Api.Repositories;
using Tyl.Stocks.Api.Services;

public static class Startup
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddControllers();

        // Add Swagger/OpenAPI
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //App Registrations
        services.AddSingleton<IStockRepository, StockRepository>();
        services.AddSingleton<ITradeRepository, TradeRepository>();
        services.AddTransient<IStockService, StockService>();
        services.AddTransient<ITradeService, TradeService>();
    }

    public static void ConfigurePipeline(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
    
    

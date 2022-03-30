using Tyl.Stocks;

var builder = WebApplication.CreateBuilder(args);

Startup.RegisterServices(builder.Services);

var app = builder.Build();

Startup.ConfigurePipeline(app);


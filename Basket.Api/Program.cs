using Basket.Api.Controllers;
using Basket.Api.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = Environment.GetEnvironmentVariable("CacheSettings:ConnectionString");
});
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddHttpClient();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddApiRoutes();
app.Run();


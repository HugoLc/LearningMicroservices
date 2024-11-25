using System.Text.Json;
using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Api.Data.Repositories;
public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;

    public BasketRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
    }

    public async Task DeleteBasketAsync(string userName)
    {
        await _redisCache.RemoveAsync(userName);
    }

    public async Task<Cart?> GetBasketAsync(string userName)
    {   
        var basket = await _redisCache.GetStringAsync(userName);

        if(String.IsNullOrEmpty(basket))
        {
            return null;
        }

        return JsonSerializer.Deserialize<Cart>(basket);
    }

    public async Task<Cart> UpdateBasketAsync(Cart basket)
    {
        await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));
        return await GetBasketAsync(basket.UserName);
    }
}

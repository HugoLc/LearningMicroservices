using Basket.Api.Entities;

namespace Basket.Api.Data.Repositories;
public interface IBasketRepository
{
    Task<Cart> GetBasketAsync(string userName);
    Task<Cart> UpdateBasketAsync(Cart basket);
    Task DeleteBasketAsync(string userName);
}

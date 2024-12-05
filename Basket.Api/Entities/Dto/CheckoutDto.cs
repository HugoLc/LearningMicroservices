using Basket.Api.Entities;

namespace Basket.Api.Entities.Dto; 
public class CheckoutDto
{
    public User Customer { get; set; }
    public Cart Basket { get; set; }
}

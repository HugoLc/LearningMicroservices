namespace Basket.Api.Entities; 
public class BasketCheckout
{
    public User Customer { get; set; }
    public decimal TotalPrice { get; set; }
    
    public List<CartItem> Items { get; set; }

    public BasketCheckout(Cart basket, User customer)
    {   
        Customer = customer;
        Items = basket.Items;
        TotalPrice = basket.TotalPrice;
    }
}

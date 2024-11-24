namespace Basket.Api.Entities; 
public class BasketCheckout
{
    public string UserName { get; set; } = "";
    public decimal TotalPrice { get; set; }
    public string Emaill { get; set; } = string.Empty;
    public string Address { get; set; } = "";
    public string CardNumber { get; set; } = "";
    public string CVV { get; set; } = "";
}

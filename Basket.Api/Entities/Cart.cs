namespace Basket.Api.Entities
{
    public class Cart
    {
        public string UserName { get; set; } ="";
        public List<CartItem> Items { get; set; } =[];        
        public Cart()
        {
        }   
        public Cart(string userName) 
        {
            UserName = userName;
        }
        public decimal TotalPrice {
            get 
            { 
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                    if(item.Discount.HasValue)
                    {
                        totalPrice -= item.Discount.Value;
                    }
                }
                return totalPrice;
            }
        }
    }
}
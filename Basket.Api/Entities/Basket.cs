namespace Basket.Api.Entities
{
    public class Basket
    {
        public string UserName { get; set; } ="";
        public List<BasketItem> Items { get; set; } =[];        
        public Basket()
        {
        }   
        public Basket(string userName) 
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
                }
                return totalPrice;
            }
        }
    }
}
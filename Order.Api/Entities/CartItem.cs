namespace Order.Api.Entities
{
    public class CartItem
    {
        public string ProductId { get; set; } = "";
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; } 
        public decimal Price { get; set; } 
        public decimal? Discount { get; set; }
    }
}
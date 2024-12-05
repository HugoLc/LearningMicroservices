
namespace Order.Api.Entities; 
public class OrderInfo
{
    public Guid OrderId { get; set; }
    public User Customer { get; set; }    
    public List<CartItem> Items { get; set; }
    
    public DateTime CreatedAt { 
        get
        {
            return DateTime.Now;
        } 
    }   
    
}

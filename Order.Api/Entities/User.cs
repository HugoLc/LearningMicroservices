

namespace Order.Api.Entities
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = "";
        public string CardNumber { get; set; } = "";
        public string CVV { get; set; } = "";
        public string UserName { get; set; } = "";
    }
}
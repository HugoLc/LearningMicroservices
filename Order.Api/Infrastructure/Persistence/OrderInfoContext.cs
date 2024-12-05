using Microsoft.EntityFrameworkCore;
using Order.Api.Entities;

namespace Order.Api.Infrastructure.Persistence
{
    public class OrderInfoContext : DbContext
    {
        public OrderInfoContext(DbContextOptions<OrderInfoContext> options) : base(options) { }

        public DbSet<OrderInfo> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<OrderInfo>()
                .HasKey(o => o.OrderId);
        }
    }
}
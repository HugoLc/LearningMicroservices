using Dapper;
using Discount.Api.Entities;
using Npgsql;

namespace Discount.Api.Data.Repositories;
public class DiscountRepository : IDiscountRepository
{
    private readonly IConfiguration _configuration;

    public DiscountRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private NpgsqlConnection GetConn()
    {
        return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
    }
    public async Task<Coupon> GetDiscount(string productName)
    {
        using var conn = GetConn();
        var coupon = conn.QueryFirstOrDefault<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
        if (coupon == null)
        {
            return new Coupon{
                ProductName = "No discount",
                Amount = 0,
                Description = "No discount"
            };
        }
        return coupon;
    }
    public Task<bool> CreateDiscount(Coupon coupon)
    {
        throw new NotImplementedException();
    }
    public Task<bool> UpdateDiscount(Coupon coupon)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeleteDiscount(string productName)
    {
        throw new NotImplementedException();
    }
}

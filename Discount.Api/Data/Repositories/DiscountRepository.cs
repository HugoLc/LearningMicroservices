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
        return new NpgsqlConnection(_configuration.GetValue<string>("DataSettings:ConnectionString"));
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
    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        var connection = GetConn();
        var affected = await connection.ExecuteAsync("INSERT INTO Coupon (Productname, Description, Amount) VALUES (@ProductName, @Description, @Amount)", new { Productname = coupon.ProductName, Description= coupon.Description, Amount = coupon.Amount });

        return affected > 1;        
    }
    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        var connection = GetConn();
        var affected = await connection.ExecuteAsync("UPDATE Coupon SET ProductName=@ProductName, Description=@Description, Amount=@Amount WHERE Id=@Id", new { Productname = coupon.ProductName, Description= coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

        return affected > 1;        
    }
    public async Task<bool> DeleteDiscount(string productName)
    {
        var connection = GetConn();
        var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @Productname", new {ProductName = productName});

        return affected > 1;     
    }
}

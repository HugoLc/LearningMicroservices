using Discount.Api.Data.Repositories;
using Discount.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers; 
public static class ApiRoutes
{
    public static void AddApiRoutes(this WebApplication app)
    {
        app.MapGet("/api/v1/get-discount/{productName}", async (string productName, [FromServices] IDiscountRepository repo)=>
        {
            var result = await repo.GetDiscount(productName);
            return Results.Ok(result);
        })
        .WithName("GetDiscount")
        .WithOpenApi();

        app.MapPost("/api/v1/create-discount", async ([FromBody] Coupon coupon, [FromServices] IDiscountRepository repo)=>
        {
            var result = await repo.CreateDiscount(coupon);
            if(result)
                return Results.CreatedAtRoute("GetDiscount", new {productName = coupon.ProductName});
            return Results.BadRequest("Desconto não foi criado");
        })
        .WithName("CreateDiscount")
        .WithOpenApi();

        app.MapPut("/api/v1/update-discount", async ([FromBody] Coupon coupon, [FromServices] IDiscountRepository repo)=>
        {
            var result = await repo.UpdateDiscount(coupon);
            if(result)
                return Results.Ok(result);
            return Results.BadRequest("Desconto não atualizado");
        })
        .WithName("UpdateDiscount")
        .WithOpenApi();

        app.MapDelete("/api/v1/delete-discount/{productName}", async(string productName,[FromServices] IDiscountRepository repo) =>
        {
            var result = await repo.DeleteDiscount(productName);
            if(result)
                return Results.NoContent();
            return Results.BadRequest("Desconto nao deletado");
        })
        .WithName("DeleteDiscount")
        .WithOpenApi();
    }
}

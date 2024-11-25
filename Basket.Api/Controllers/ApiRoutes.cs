using Basket.Api.Data.Repositories;
using Basket.Api.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers; 
public static class ApiRoutes
{   
    public static void AddApiRoutes(this WebApplication app)
    {
        app.MapGet("/api/v1/get-basket/{userName}", async (string userName, [FromServices] IBasketRepository repository)=>
        {
            var basket = await repository.GetBasketAsync(userName);
            return Results.Ok(basket ?? new Cart(userName));
        })
        .WithName("GetBasket")
        .WithOpenApi();

        app.MapPost("/api/v1/update-basket",async ([FromBody] Cart basket, [FromServices] IBasketRepository repo) =>
        {
            return Results.Ok(await repo.UpdateBasketAsync(basket));
        })
        .WithName("UpadateBasket")
        .WithOpenApi();

        app.MapDelete("/api/v1/delete-basket/{userName}", async (string userName, [FromServices] IBasketRepository repo)=>
        {
            await repo.DeleteBasketAsync(userName);
            return Results.NoContent();
        })
        .WithName("DeleteBasket")
        .WithOpenApi();
    }
}

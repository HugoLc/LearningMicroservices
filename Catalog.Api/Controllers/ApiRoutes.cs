using Catalog.Api.Data.Repositories;
using Catalog.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers; 
public static class ApiRoutes
{
    public static void AddRoutes(this WebApplication app)
    {
        app.MapGet("/hello-world", async () =>
        {
            return Results.Ok("hello");
        })
        .WithName("HelloWorld")
        .WithOpenApi();

        app.MapGet("/api/v1/get-products", async ([FromServices] IProductRepository productRepository) =>
        {
            var products = await productRepository.GetProductsAsync();
            return Results.Ok(products);
        })
        .WithName("GetProducts")
        .WithOpenApi();

        app.MapGet("/api/v1/get-product-by-id/{id}", async ([FromRoute] string id, [FromServices] IProductRepository productRepository)=>
        {
            var product = await productRepository.GetProductByIdAsync(id);
            if(product is not null){
                return Results.Ok(product);
            }    
            return Results.NotFound();
        })
        .WithName("GetProductById")
        .WithOpenApi();

        app.MapGet("/api/v1/get-products-by-name/{name}", async ([FromRoute] string name, [FromServices] IProductRepository productRepository)=>
        {
            var products = await productRepository.GetProductByName(name);
            if(products is not null || products?.Count() > 0){
                return Results.Ok(products);
            }    
            return Results.NotFound();
        })
        .WithName("GetProductsByName")
        .WithOpenApi();

        app.MapGet("/api/v1/get-products-by-category/{category}", async ([FromRoute] string category, [FromServices] IProductRepository productRepository)=>
        {
            var products = await productRepository.GetProductByCategory(category);
            if(products is not null || products?.Count() > 0){
                return Results.Ok(products);
            }    
            return Results.NotFound();
        })
        .WithName("GetProductsByCategory")
        .WithOpenApi();

        app.MapPost("/api/v1/create-product", async ([FromBody] Product product, [FromServices] IProductRepository productRepository) =>
        {
            if(product is null)
            {
                return Results.BadRequest();
            }
            await productRepository.CreateProduct(product);
            return Results.CreatedAtRoute(
                routeName: "GetProductById",  // Nome da rota definida
                routeValues: new { id = product.Id },  // Valores necessários para preencher os parâmetros da rota
                value: product  // Retorna o produto criado no corpo da resposta
            );
        })
        .WithName("CreateProduct")
        .WithOpenApi();

        app.MapDelete("/api/v1/delete-product/{id}", async (string id, [FromServices] IProductRepository productRepository)=>
        {
            var isDeleted = await productRepository.DeleteProduct(id);
            if(isDeleted){
                return Results.NoContent();
            }
            return Results.NotFound();
        })
        .WithName("DeleteProduct")
        .WithOpenApi();

        app.MapPut("/api/v1/update-product", async ([FromBody] Product product, [FromServices] IProductRepository productRepository)=>
        {
            if(product is null)
            {
                return Results.BadRequest();
            }
            var isUpdated = await productRepository.UpdateProduct(product);
            if(isUpdated){
                return Results.Ok(product);
            }
            return Results.NotFound();
        })
        .WithName("UpdateProduct")
        .WithOpenApi();
    }
}

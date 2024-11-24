using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "produto 1",
                    Description =" drescricao 1",
                    Category = "calcado",
                    Image = "imagem 1",
                    Price = 200
                },
                new Product()
                {
                    Name = "produto 2",
                    Description =" descricao 2",
                    Category = "calcado",
                    Image = "imagem 2",
                    Price = 300
                },
                new Product()
                {
                    Name = "produto 3",
                    Description =" descricao 3",
                    Category = "camisa",
                    Image = "imagem 3",
                    Price = 70
                },
                new Product()
                {
                    Name = "produto 4",
                    Description =" descricao 4",
                    Category = "calca",
                    Image = "imagem 4",
                    Price = 90
                }
            };
        }
    }
}
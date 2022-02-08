using Net5.Deployment.API.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;

namespace Net5.Deployment.API.Infrastructure.Data.Contexts
{
    public static class ProductContextExtensions
    {
        public static void EnsureSeeDataForContext(this ProductContext context)
        {
            context.Products.RemoveRange(context.Products);
            context.SaveChanges();

            List<Product> products = new List<Product>();

            products.Add(new Product
            {
                ProductId = new Guid("FE243451-E3F4-42FA-93BB-B4DC8C6144A4"),
                Description = "Xbox Series X, Console",
                Price = (decimal)499.99,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            products.Add(new Product
            {
                ProductId = new Guid("49BC36D4-37F0-4CAD-83BF-1026A04DF1D0"),
                Description = "NBA 2K21 - Xbox Series X",
                Price = (decimal)69.99,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            products.Add(new Product
            {
                ProductId = new Guid("0F7C3D83-15CD-4F32-9EF2-9FE3270BE286"),
                Description = "Nintendo Switch with Neon Blue and Neon Red Joy‑Con",
                Price = (decimal)458.99,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            products.Add(new Product
            {
                ProductId = new Guid("FB678BD3-D178-4ED0-87E2-2A3BC81CB32D"),
                Description = "The Legend of Zelda: Breath of the Wild - Nintendo Switch",
                Price = (decimal)43.99,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });
            products.Add(new Product
            {
                ProductId = new Guid("AD48BA04-D528-43C4-855D-B2F2B7D8215F"),
                Description = "Marvel's Spider-Man: Miles Morales Launch Edition - PlayStation 4",
                Price = (decimal)52.99,
                Created = DateTime.Now,
                Updated = DateTime.Now
            });

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}

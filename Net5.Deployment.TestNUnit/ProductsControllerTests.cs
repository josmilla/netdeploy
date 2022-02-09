using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Net5.Deployment.API.Controllers;
using Net5.Deployment.API.Infrastructure.Data.Contexts;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using Net5.Deployment.API.Infrastructure.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Deployment.TestNUnit
{
    [TestFixture]
    public class ProductsControllerTests
    {
        private DbContextOptions<ProductContext> _dbContextOptions = new DbContextOptionsBuilder<ProductContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .Options;

        private ProductRepository _productRepository;
        private ProductsController _controller;

        [OneTimeSetUp]
        public void Setup()
        {
            SeedDb();
            _productRepository = new ProductRepository(new ProductContext(_dbContextOptions));
            _controller = new ProductsController(_productRepository);
        }

        [Test]
        public async Task GetProductsAsync()
        {
            var result = await _controller.GetProductsAsync();
            var products = result.As<IEnumerable<Product>>();            
            products.Should().NotBeNullOrEmpty();
            products.Count().Should().Be(5);
            //Assert.AreEqual(5, result.Count());
        }
        [Test]
        public async Task GetAsync()
        {
            var result = await _controller.GetAsync(new Guid("02540696-8994-42c7-b703-e630223883ab"));
            var product = result.As<Product>();
            product.Should().NotBeNull();
            product.Description.Should().Be("Teclado");            
        }

        private void SeedDb()
        {
            using var context = new ProductContext(_dbContextOptions);

            List<Product> products = new List<Product>
            {
                new Product{ ProductId = new Guid("35749678-0d54-44bc-83d5-274d57898f30"),Description="Mouse",Price=20_45,Created=DateTime.Now, Updated=DateTime.Now },
                new Product{ ProductId = new Guid("02540696-8994-42c7-b703-e630223883ab"),Description="Teclado",Price=25_62,Created=DateTime.Now, Updated=DateTime.Now },
                new Product{ ProductId = new Guid("03404a76-0c4d-4eda-bb45-8df096cb976d"),Description="Monitor LG 24 Pulgadas",Price=103_58,Created=DateTime.Now, Updated=DateTime.Now },
                new Product{ ProductId = new Guid("993feb68-3e87-4f9b-b45b-cbf13712de06"),Description="Silla Gamer",Price=256_78,Created=DateTime.Now, Updated=DateTime.Now },
                new Product{ ProductId = new Guid("947e2439-baef-4216-89d6-3f9f28d2a702"),Description="WebCam Xioami",Price=86_94,Created=DateTime.Now, Updated=DateTime.Now }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Net5.Deployment.API.Controllers;
using Net5.Deployment.API.Infrastructure.Data.Contexts;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using Net5.Deployment.API.Infrastructure.Data.Repositories;

namespace Net5.Deployment.Spec.StepDefinitions
{
    [Binding]
    public sealed class ProductsControllerStepDefinitions
    {
        private DbContextOptions<ProductContext> _dbContextOptions = new DbContextOptionsBuilder<ProductContext>()
        .UseInMemoryDatabase(databaseName: "MempryDb")
        .Options;

        private ProductRepository _productRepository;
        private ProductsController _controller;
        private IEnumerable<Product> _products;
        private Product _product;

        public ProductsControllerStepDefinitions()
        {
            SeedDb();
            _productRepository = new ProductRepository(new ProductContext(_dbContextOptions));
            _controller = new ProductsController(_productRepository);
            _products = new List<Product>();
            _product = new Product();
        }

        [When("we get the list of products")]
        public async Task WhenWeGetTheListOfProducts()
        {
            _products = await _controller.GetProductsAsync();
        }
        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _products.Count().Should().Be(result);
        }

        [Given("that I get the product with Id (.*)")]
        public async void GivenThatIGetTheProductWithId(Guid productId)
        {
            _product = await _controller.GetAsync(productId);
        }
        [Then("the product description must be (.*)")]
        public void ThenTheProductDescriptionMustBe(string result)
        {
            _product.Description.Should().Be(result);
        }

        private void SeedDb()
        {
            using var context = new ProductContext(_dbContextOptions);
            context.Database.EnsureDeleted();

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
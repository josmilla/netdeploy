using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using Net5.Deployment.API.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Deployment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<Product> GetAsync(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Product product)
        {
            var result = await _productRepository.InsertAsync(product);
            return CreatedAtRoute("GetProduct", new { id = result.ProductId }, result);            
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] Product product)
        {
            var result = await _productRepository.UpdateAsync(id, product);
            return Ok(result);

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _productRepository.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        
    }
}

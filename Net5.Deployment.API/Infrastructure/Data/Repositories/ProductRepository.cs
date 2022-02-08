using Microsoft.EntityFrameworkCore;
using Net5.Deployment.API.Infrastructure.Data.Contexts;
using Net5.Deployment.API.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Deployment.API.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext _context;
        private DbSet<Product> _dbSet;
        public ProductRepository(ProductContext context)
        {
            _context = context;
            _dbSet = context.Set<Product>();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await _dbSet.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
        }
        public async Task<Product> InsertAsync(Product product)
        {
            _dbSet.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateAsync(Guid productId, Product product)
        {
            Product productToUpdate = await GetProductByIdAsync(productId);
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.Created = product.Created;
            productToUpdate.Updated = product.Updated;

            _dbSet.Update(productToUpdate);
            await _context.SaveChangesAsync();

            return productToUpdate;
        }

        public async Task<Product> DeleteAsync(Guid productId)
        {
            Product productToDelete = await GetProductByIdAsync(productId);

            _dbSet.Remove(productToDelete);
            await _context.SaveChangesAsync();
            return productToDelete;
        }
    }
}

using Net5.Deployment.API.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5.Deployment.API.Infrastructure.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> DeleteAsync(Guid productId);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<List<Product>> GetProductsAsync();
        Task<Product> InsertAsync(Product product);
        Task<Product> UpdateAsync(Guid productId, Product product);
    }
}
using Net5.Deployment.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Net5.Deployment.Client.Infrastructure.Agents
{
    public class ProductsAgent
    {
        private ProductsHttpClient _client;
        public ProductsAgent(ProductsHttpClient client)
        {
            _client = client;
        }

        public async Task<List<Product>> GetProductsAsync(){
            return await _client.GetProductsAsync();
        }
    }
}

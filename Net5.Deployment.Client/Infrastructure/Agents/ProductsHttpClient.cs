using Microsoft.Extensions.Configuration;
using Net5.Deployment.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Net5.Deployment.Client.Infrastructure.Agents
{
    public class ProductsHttpClient
    {
        private HttpClient _httpClient;
        private string productsApiUrl = "";
        public ProductsHttpClient(HttpClient httpClient,IConfiguration configuration)
        {
            productsApiUrl = configuration.GetSection("ProductUrl").Value;
            InitializeClient(httpClient);
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("");
        }
        private void InitializeClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(productsApiUrl);
            _httpClient = httpClient;
        }
    }
}

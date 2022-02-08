using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Net5.Deployment.Client.Infrastructure.Agents;
using Net5.Deployment.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.Deployment.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductsAgent _productsAgent;

        public HomeController(ILogger<HomeController> logger,ProductsAgent productsAgent)
        {
            _logger = logger;
            _productsAgent = productsAgent;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Product> products = await _productsAgent.GetProductsAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

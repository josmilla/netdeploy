using System;

namespace Net5.Deployment.Client.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}

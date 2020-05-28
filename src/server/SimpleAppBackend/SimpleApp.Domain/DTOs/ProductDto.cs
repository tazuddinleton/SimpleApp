using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Domain.DTOs
{
    // The dto is currently identical to entity, but later I will add some detail to it
    public class ProductDto
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }        
        public decimal UnitPrice { get; set; }

        // This mapping could have been done using tools like Automapper 
        // but to keep things simple
        public static ProductDto FromEntity(Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                UnitPrice = product.UnitPrice
            };
        }

        public static Product ToEntity(ProductDto dto)
        {
            return new Product
            {
                ProductId = (int)dto.ProductId,
                ProductName = dto.ProductName,
                Description = dto.Description,
                UnitPrice = dto.UnitPrice
            };
        }
    }
}

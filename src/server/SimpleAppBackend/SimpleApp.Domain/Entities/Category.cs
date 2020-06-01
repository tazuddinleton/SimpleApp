using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; private set; }
    }
}

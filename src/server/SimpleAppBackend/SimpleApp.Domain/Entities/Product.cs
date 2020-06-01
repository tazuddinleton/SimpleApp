using SimpleApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SimpleApp.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        // decimal unit price will be problematic in real situation for fractions
        public decimal UnitPrice { get; set; }

    }
}

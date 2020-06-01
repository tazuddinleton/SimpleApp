using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleApp.Domain.DTOs
{
    public class DashboardDto
    {
        public int TotalNumOfProducts { get; set; }
        public int NumOfProductByUser { get; set; }



        public IEnumerable<ProductCategories> ProductCategories { get; set; }
    }

    public class ProductCategories 
    {
        public string Category { get; set; }
        public int NumberOfProducts { get; set; }
    }
}

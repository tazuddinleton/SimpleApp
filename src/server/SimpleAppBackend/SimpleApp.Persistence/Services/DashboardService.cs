﻿using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly SimpleAppDbContext _context;
        private readonly ICurrentUserService _currentUser;

        public DashboardService(SimpleAppDbContext context, ICurrentUserService currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public Task<DashboardDto> GetDashboardInfo()
        {
            var dashboard = new DashboardDto();
            dashboard.TotalNumOfProducts = _context.Products.Count();
            dashboard.NumOfProductByUser = _context.Products.Count(x => x.CreatedBy == _currentUser.UserId);

            dashboard.ProductCategories = _context.Categories
                .Include(p => p.Products)
                .Select(c => new ProductCategories
                {
                    Category = c.CategoryName,
                    NumberOfProducts = c.Products.Count
                })
                .ToList();

            return Task.FromResult(dashboard);
        }
    }
}

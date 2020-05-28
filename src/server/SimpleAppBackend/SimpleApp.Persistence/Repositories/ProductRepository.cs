using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.DTOs;
using SimpleApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SimpleAppDbContext _context;

        public ProductRepository(SimpleAppDbContext context)
        {
            _context = context;
        }
        // Recently gained some async knowledge, putting cancellation token in async method makes sense because this could provide
        // some performance benefits if user decides to cancel some running request. Though I have no plan to implement that here.

        public async Task<ProductDto> GetById(int id, CancellationToken ct)
        {
            var product = await _context.Products.FindAsync(id, ct);
            return ProductDto.FromEntity(product);
        }

        public async Task<int> Upsert(ProductDto dto, CancellationToken ct)
        {
            Product entity;
            if (dto.ProductId.HasValue)
            {
                entity = _context.Products.Find(dto.ProductId);
            }
            else
            {
                entity = ProductDto.ToEntity(dto);
                _context.Add(entity);
            }
            await _context.SaveChangesAsync();
            return entity.ProductId;
        }

        public async Task<IEnumerable<ProductDto>> GetAll(CancellationToken ct)
        {
            return await _context.Products
                .Select(p => ProductDto.FromEntity(p))
                .ToListAsync(ct);
        }
    }
}

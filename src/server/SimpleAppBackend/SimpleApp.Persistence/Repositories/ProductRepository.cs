using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.DTOs;
using SimpleApp.Domain.Entities;
using SimpleApp.Persistence.Exceptions;
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
        

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return ProductDto.FromEntity(product);
        }

        public async Task<int> UpsertAsync(ProductDto dto)
        {
            Product entity;
            if (dto.ProductId.Value > 0)
            {
                entity = _context.Products.Find(dto.ProductId);
                if (entity is null)
                    // TODO: Configure global exception handler and handle this exception
                    throw new RecordNotFoundException("Record you tried to update is either deleted or does not exists.");
                entity.ProductName = dto.ProductName;
                entity.Description = dto.Description;
                entity.UnitPrice = dto.UnitPrice;
            }
            else
            {
                entity = ProductDto.ToEntity(dto);
                _context.Add(entity);
            }
            await _context.SaveChangesAsync();
            return entity.ProductId;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _context.Products
                .Select(p => ProductDto.FromEntity(p))
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = _context.Products.Find(id);
            if (entity != null)
                _context.Remove(entity);
             await _context.SaveChangesAsync();
        }
    }
}

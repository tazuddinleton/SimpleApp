using SimpleApp.Domain.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAll(CancellationToken ct);
        Task<ProductDto> GetById(int id, CancellationToken ct);
        Task<int> Upsert(ProductDto dto, CancellationToken ct);
    }
}
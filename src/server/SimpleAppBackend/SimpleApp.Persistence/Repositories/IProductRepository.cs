using SimpleApp.Domain.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.Persistence.Repositories
{
    // I"m not going to use Cencellation token
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<int> UpsertAsync(ProductDto dto);
        Task DeleteAsync(int id);
    }
}
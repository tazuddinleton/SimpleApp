using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using SimpleApp.Domain.DTOs;
using SimpleApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleApp.Api.Controllers
{
    
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepo)
        {
            _productRepository = productRepo;
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<ProductDto>> Get([FromRoute] int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            return Ok(await _productRepository.GetAllAsync());
        }
        
        [HttpPost]                
        public async Task<ActionResult<int>> Upsert([FromBody] ProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(await _productRepository.UpsertAsync(product));
        }
        // Could be useful to return boolean to indicate success or failure sometimes, but i think void is sufficient because
        // if found then it will be deleted for sure and if it doesn't exists then it's already gone. If any exception is thrown 
        // it's a failure anyways.
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _productRepository.DeleteAsync(id);
            return Ok();
        }
    }
}

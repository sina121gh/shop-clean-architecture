using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;

namespace Shop.API.Controllers
{
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        #region Ctor

        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #endregion

        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            return Ok(product);
        }
    }
}

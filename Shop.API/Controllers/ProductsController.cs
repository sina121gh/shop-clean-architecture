using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using Shop.Application.Interfaces;
using Mapster;
using Shop.Application.DTOs.Product;
using MapsterMapper;

namespace Shop.API.Controllers
{
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        #region Ctor

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ShowProductDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowProductDto>> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
                return NotFound();

            return Ok(_mapper.Map<ShowProductDto>(product));
        }


        [HttpPost]
        public async Task<ActionResult<ShowProductDto>> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);

            if (!await _categoryRepository.DoesExistByIdAsync(product.CategoryId)) return NotFound();

            await _productRepository.AddAsync(product);

            try
            {
                await _productRepository.SaveChangesAsync();
                return CreatedAtAction("GetProductByIdAsync", _mapper.Map<ShowProductDto>(product));
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(int id, Product product)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(id);

            if (productToUpdate is null) return NotFound();

            _mapper.Map(product, productToUpdate);

            _productRepository.Update(product);

            try
            {
                await _productRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null) return NotFound();

           _productRepository.Delete(product);

            try
            {
                await _productRepository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

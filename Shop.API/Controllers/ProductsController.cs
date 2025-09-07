using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using Mapster;
using Shop.Application.DTOs.Product;
using MapsterMapper;
using Shop.Application.Persistence;
using MediatR;
using Shop.Application.Features.Products.Queries.GetProductById;
using Shop.Application.Features.Products.Queries.GetAllProducts;

namespace Shop.API.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        #region Ctor

        private readonly IMediator _mediator;

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator,
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _mediator = mediator;

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowProductDto>>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery() { PageNumber = pageNumber, PageSize = pageSize}));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowProductWithCategoryDto>> GetProductByIdAsync(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<ActionResult<ShowProductDto>> CreateProductAsync([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _mapper.Map<Product>(createProductDto);

            if (!await _categoryRepository.DoesExistByIdAsync(product.CategoryId)) return NotFound();

            await _productRepository.AddAsync(product);

            try
            {
                await _productRepository.SaveChangesAsync();
                return Created();
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(int id, [FromBody] CreateProductDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productToUpdate = await _productRepository.GetByIdAsync(id);

            if (productToUpdate is null) return NotFound();

            _mapper.Map(product, productToUpdate);

            _productRepository.Update(productToUpdate);

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

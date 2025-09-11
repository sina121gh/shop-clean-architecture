using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using Mapster;
using MapsterMapper;
using Shop.Application.Persistence;
using MediatR;
using Shop.Application.Features.Products.Queries.GetProductById;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using ErrorOr;
using Shop.API.Extensions;
using Shop.Application.Features.Products.Commands;

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
        public async Task<IActionResult> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _mediator.Send(new GetAllProductsQuery() { PageNumber = pageNumber, PageSize = pageSize });
            return this.ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {

            var result = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            return this.ToActionResult(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto createProductDto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateProductCommand() { Product = createProductDto });
            return this.ToActionResult(result);
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

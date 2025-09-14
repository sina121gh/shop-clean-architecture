using ErrorOr;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Features.Products.Commands.CreateProduct;
using Shop.Application.Features.Products.Commands.DeleteProduct;
using Shop.Application.Features.Products.Commands.UpdateProduct;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Features.Products.Queries.GetProductById;
using Shop.Application.Parameters;
using Shop.Application.Persistence;
using Shop.Domain.Entities;

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
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllProductsParameters filter)
        {
            var result = await _mediator.Send(new GetAllProductsQuery() { PageNumber = filter.PageNumber,
                PageSize = filter.PageSize, CategoryId = filter.CategoryId, MinPrice = filter.MinPrice, MaxPrice = filter.MaxPrice });
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
            var result = await _mediator.Send(new CreateProductCommand() { Product = createProductDto });
            return this.ToActionResult(result, 201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, [FromBody] CreateProductDto product)
        {
            var result = await _mediator.Send(new UpdateProductCommand() { Id = id, Product = product });
            return this.ToActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand() { Id = id});
            return this.ToActionResult(result);
        }
    }
}

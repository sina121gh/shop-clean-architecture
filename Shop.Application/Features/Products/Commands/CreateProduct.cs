using ErrorOr;
using MapsterMapper;
using MediatR;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Persistence;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<ErrorOr<ShowProductDto>>
    {
        public CreateProductDto Product { get; set; }
    }

    class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<ShowProductDto>>
    {
        #region Ctor

        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<ErrorOr<ShowProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);
            await _productRepository.AddAsync(product);

            try
            {
                await _productRepository.SaveChangesAsync();
                return _mapper.Map<ShowProductDto>(product);
            }
            catch (Exception)
            {
                return Error.Unexpected();
            }
        }
    }
}

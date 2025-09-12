using ErrorOr;
using MapsterMapper;
using MediatR;
using Shop.Application.Features.Products.Commands.CreateProduct;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ErrorOr<ShowProductDto>>
    {
        public int Id { get; set; }

        public CreateProductDto Product { get; set; }
    }

    class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<ShowProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<ErrorOr<ShowProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            _mapper.Map(request.Product, product);
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

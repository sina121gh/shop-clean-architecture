using ErrorOr;
using MapsterMapper;
using MediatR;
using Shop.Application.Exceptions;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ErrorOr<ShowProductWithCategoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ErrorOr<ShowProductWithCategoryDto>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowProductWithCategoryDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdIncludingCategory(request.Id);
            if (product == null) return Error.NotFound("محصول پیدا نشد", $"محصول با ایدی {request.Id} پیدا نشد");
            return _mapper.Map<ShowProductWithCategoryDto>(product);
        }
    }
}

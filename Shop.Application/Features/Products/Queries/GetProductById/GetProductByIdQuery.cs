using MapsterMapper;
using MediatR;
using Shop.Application.DTOs.Product;
using Shop.Application.Exceptions;
using Shop.Application.Persistence;
using Shop.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ShowProductWithCategoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ShowProductWithCategoryDto>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<ShowProductWithCategoryDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdIncludingCategory(request.Id);
            if (product == null) throw new NotFoundException("product", request.Id);
            return new Response<ShowProductWithCategoryDto>(_mapper.Map<ShowProductWithCategoryDto>(product));
        }
    }
}

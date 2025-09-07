using MapsterMapper;
using MediatR;
using Shop.Application.DTOs.Product;
using Shop.Application.Persistence;
using Shop.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<PagedResponse<IEnumerable<ShowProductDto>>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<IEnumerable<ShowProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ShowProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetPagedResponseAsync(request.PageNumber, request.PageSize);
            return new PagedResponse<IEnumerable<ShowProductDto>>(_mapper.Map<IEnumerable<ShowProductDto>>(products),
                request.PageNumber, request.PageSize, products.Count);
        }
    }
}

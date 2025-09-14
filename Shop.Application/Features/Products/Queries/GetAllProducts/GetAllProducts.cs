using ErrorOr;
using MapsterMapper;
using MediatR;
using Shop.Application.DTOs;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ErrorOr<PagedResult<ShowProductDto>>>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? Query { get; set; }

        public int? CategoryId { get; set; }

        public int? MinPrice { get; set; }

        public int? MaxPrice { get; set; }
    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ErrorOr<PagedResult<ShowProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<PagedResult<ShowProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.FilterProductsAsync(request.PageNumber, request.PageSize,
                request.Query, request.CategoryId, request.MinPrice, request.MaxPrice);

            return new PagedResult<ShowProductDto>(_mapper.Map<IReadOnlyList<ShowProductDto>>(products.Items),
                products.PageNumber, products.PageSize, products.TotalRecords);
        }
    }
}

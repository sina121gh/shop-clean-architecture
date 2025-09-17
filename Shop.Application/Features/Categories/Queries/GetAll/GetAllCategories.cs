using Shop.Application.DTOs.Category;

namespace Shop.Application.Features.Categories.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequest<ErrorOr<PagedResult<ShowCategoryDto>>>
    {
        public FilterAllEntitiesParameters Parameters { get; set; }
    }

    class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, ErrorOr<PagedResult<ShowCategoryDto>>>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<PagedResult<ShowCategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.FilterCategoriesAsync(request.Parameters.PageNumber,
                request.Parameters.PageSize, request.Parameters.Query, request.Parameters.SortBy,
                request.Parameters.SortDirection);

            return new PagedResult<ShowCategoryDto>(_mapper.Map<IReadOnlyList<ShowCategoryDto>>(categories.Items),
                categories.PageNumber, categories.PageSize, categories.TotalRecords);
        }
    }
}

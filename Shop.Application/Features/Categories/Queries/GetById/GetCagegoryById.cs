using ErrorOr;
using MapsterMapper;
using MediatR;
using Shop.Application.DTOs.Category;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<ErrorOr<ShowCategoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetCagegoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, ErrorOr<ShowCategoryDto>>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public GetCagegoryByIdQueryHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowCategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                return Error.NotFound(description: $"دسته بندی با آیدی {request.Id} یافت نشد");

            return _mapper.Map<ShowCategoryDto>(category);
        }
    }
}

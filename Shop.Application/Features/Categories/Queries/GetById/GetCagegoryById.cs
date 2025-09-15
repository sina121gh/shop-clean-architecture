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
    public class GetCagegoryByIdQuery : IRequest<ErrorOr<ShowCategoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetCagegoryByIdQueryHandler : IRequestHandler<GetCagegoryByIdQuery, ErrorOr<ShowCategoryDto>>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public GetCagegoryByIdQueryHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowCategoryDto>> Handle(GetCagegoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                return Error.NotFound();

            return _mapper.Map<ShowCategoryDto>(category);
        }
    }
}

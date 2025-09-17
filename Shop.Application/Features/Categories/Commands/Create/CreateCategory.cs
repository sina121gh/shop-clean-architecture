using Shop.Application.DTOs.Category;

namespace Shop.Application.Features.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<ErrorOr<ShowCategoryDto>>
    {
        public CreateCategoryDto Category { get; set; }
    }

    class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<ShowCategoryDto>>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowCategoryDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.Category);
            await _categoryRepository.AddAsync(category);

            try
            {
                await _categoryRepository.SaveChangesAsync();
                return _mapper.Map<ShowCategoryDto>(category);
            }
            catch (Exception)
            {
                return Error.Unexpected(description: "خطایی در ثبت اطلاعات رخ داد");
            }
        }
    }
}

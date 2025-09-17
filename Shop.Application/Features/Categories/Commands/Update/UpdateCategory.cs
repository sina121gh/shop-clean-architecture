using Shop.Application.DTOs.Category;
using Shop.Application.Features.Categories.Commands.Create;

namespace Shop.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<ErrorOr<ShowCategoryDto>>
    {
        public int Id { get; set; }
        public CreateCategoryDto Category { get; set; }
    }

    class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ErrorOr<ShowCategoryDto>>
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowCategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                return Error.NotFound("دسته بندی یافت نشد");

            _mapper.Map(request.Category, category);

            try
            {
                await _categoryRepository.SaveChangesAsync();
                return _mapper.Map<ShowCategoryDto>(category);
            }
            catch (Exception)
            {
                return Error.Unexpected("خطایی در ثبت اطلاعات رخ داد");
            }
        }
    }
}

namespace Shop.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<ErrorOr<Unit>>
    {
        public int Id { get; set; }
    }

    class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ErrorOr<Unit>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<ErrorOr<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
                return Error.NotFound("دسته بندی یافت نشد");

            _categoryRepository.Delete(category);

            try
            {
                await _categoryRepository.SaveChangesAsync();
                return Unit.Value;
            }
            catch (Exception)
            {
                return Error.Unexpected(description: "خطایی در ثبت اطلاعات رخ داد");
            }
        }
    }
}

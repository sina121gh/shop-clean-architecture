namespace Shop.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("آیدی دسته بندی را وارد کنید")
                .MustAsync(async (id, token) => await _categoryRepository.DoesExistByIdAsync(id))
                .WithMessage("دسته بندی یافت نشد").WithErrorCode("404");
        }
    }
}

using Shop.Application.Features.Categories.Commands.Create;

namespace Shop.Application.Features.Categories.Commands.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(c => c.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("آیدی را صحیح وارد کنید")
                .MustAsync(async (id, token) => await _categoryRepository.DoesExistByIdAsync(id))
                .WithMessage("دسته بندی یافت نشد")
                .WithErrorCode("404")
                .DependentRules(() =>
                {
                    RuleFor(c => c.Category).SetValidator(new CreateCategoryDtoValidator());
                });
        }
    }
}

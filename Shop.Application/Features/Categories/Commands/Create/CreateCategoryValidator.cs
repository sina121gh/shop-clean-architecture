namespace Shop.Application.Features.Categories.Commands.Create
{

    class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(50)
                .NotEmpty();
        }
    }

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Category).SetValidator(new CreateCategoryDtoValidator());
        }
    }
}

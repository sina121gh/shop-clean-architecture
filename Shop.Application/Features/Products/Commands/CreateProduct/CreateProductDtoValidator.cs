namespace Shop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.CategoryId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    return await _categoryRepository.DoesExistByIdAsync(id);
                }).WithMessage("دسته بندی یافت نشد")
                .WithErrorCode("404");

            RuleFor(p => p.Name)
                .MaximumLength(50)
                .NotEmpty()
                .WithMessage("نام باید حداکثر 50 نویسه باشد");

            RuleFor(p => p.Description)
                .Length(1, 200)
                .NotEmpty();

            RuleFor(p => p.Price)
                .GreaterThan(0)
                .NotNull();

            RuleFor(p => p.IsActive)
                .NotNull();
        }
    }
}

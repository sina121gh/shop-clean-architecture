namespace Shop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductCommandValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Product).SetValidator(new CreateProductDtoValidator(_categoryRepository));
        }
    }
}

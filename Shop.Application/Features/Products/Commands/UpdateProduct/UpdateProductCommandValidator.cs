using FluentValidation;
using Shop.Application.Features.Products.Commands.CreateProduct;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandValidator(ICategoryRepository categoryRepository
            , IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;


            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("آیدی محصول را وارد کنید").WithErrorCode("404")
                .MustAsync(async (id, token) => await _productRepository.DoesExistByIdAsync(id))
                .WithMessage("محصول یافت نشد")
                .WithErrorCode("404")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Product).SetValidator(new CreateProductDtoValidator(_categoryRepository));
                });
        }
    }
}

using FluentValidation;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("آیدی محصول را وارد کنید").WithErrorCode("404")
                .MustAsync(async (id, token) => await _productRepository.DoesExistByIdAsync(id))
                .WithMessage("محصول یافت نشد").WithErrorCode("404");
        }
    }
}

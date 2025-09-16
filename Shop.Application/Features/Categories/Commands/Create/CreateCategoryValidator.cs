using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategory>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Category).SetValidator(new CreateCategoryDtoValidator());
        }
    }
}

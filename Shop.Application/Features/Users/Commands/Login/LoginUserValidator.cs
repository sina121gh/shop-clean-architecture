using Shop.Application.Features.Users.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Users.Commands.Login
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(u => u.UserName)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(u => u.Password)
                .MaximumLength(100)
                .NotEmpty();
        }
    }

    class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(c => c.Login).SetValidator(new LoginUserDtoValidator());
        }
    }
}

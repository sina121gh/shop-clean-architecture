using Shop.Application.Features.Users.Commands.Create;

namespace Shop.Application.Features.Users.Commands.Register
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(u => u.UserName)
                .MaximumLength(20)
                .NotEmpty();

            RuleFor(u => u.Password)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(u => u.Email)
                .MaximumLength(100)
                .NotEmpty()
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                .WithMessage("ایمیل را صحیح وارد نمایید");
        }
    }

    class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.RegisterUserDto).SetValidator(new RegisterUserDtoValidator());
        }
    }
}

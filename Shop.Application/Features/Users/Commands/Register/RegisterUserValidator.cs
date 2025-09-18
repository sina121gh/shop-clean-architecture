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

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(c => c.RegisterUserDto).SetValidator(new RegisterUserDtoValidator());

            RuleFor(c => c.RegisterUserDto.UserName)
                .MustAsync(async (userName, cancellationToken) => !await _userRepository.DoesUserNameExistAsync(userName))
                .WithMessage("این نام کاربری قبلا ثبت شده است");

            RuleFor(c => c.RegisterUserDto.Email)
                .MustAsync(async (email, cancellationToken) => !await _userRepository.DoesEmailExistAsync(email))
                .WithMessage("این ایمیل قبلا ثبت شده است");
        }
    }
}

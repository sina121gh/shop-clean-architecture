using Shop.Application.Contracts.Persistence;
using Shop.Application.Features.Users.Commands.Register;

namespace Shop.Application.Features.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommandValdator : AbstractValidator<UpdateProfileCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateProfileCommandValdator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            int userId = 0;

            RuleFor(c => c.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("آیدی را صحیح وارد کنید")
                .MustAsync(async (id, token) =>
                {
                    userId = id;
                    return await _userRepository.DoesExistByIdAsync(id);
                })
                .WithMessage("کاربر یافت نشد")
                .WithErrorCode("404")
                .DependentRules(() =>
                {
                    RuleFor(c => c.UserDto.Password)
                        .MaximumLength(100)
                        .NotEmpty();

                    RuleFor(c => c.UserDto.UserName)
                        .MaximumLength(20)
                        .NotEmpty()
                        .MustAsync(async (userName, cancellationToken) => !await _userRepository.DoesUserNameExistAsync(userName, userId))
                        .WithMessage("این نام کاربری قبلا ثبت شده است");

                    RuleFor(c => c.UserDto.Email)
                        .MaximumLength(100)
                        .NotEmpty()
                        .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
                        .WithMessage("ایمیل را صحیح وارد نمایید")
                        .MustAsync(async (email, cancellationToken) => !await _userRepository.DoesEmailExistAsync(email, userId))
                        .WithMessage("این ایمیل قبلا ثبت شده است");
                });
        }
    }
}

using FluentValidation;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Features.Categories.Commands.Create;
using Shop.Application.Features.Users.Commands.Register;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Users.Commands.UpdateProfile
{
    public class UpdateProfileValdator : AbstractValidator<UpdateProfileCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateProfileValdator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UpdateProfileValdator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("آیدی را صحیح وارد کنید")
                .MustAsync(async (id, token) => await _userRepository.DoesExistByIdAsync(id))
                .WithMessage("کاربر یافت نشد")
                .WithErrorCode("404")
                .DependentRules(() =>
                {
                    RuleFor(c => c.UserDto).SetValidator(new RegisterUserDtoValidator());
                });
        }
    }
}

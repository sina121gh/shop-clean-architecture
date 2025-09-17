using FluentValidation;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("آیدی را وارد کنید")
                .MustAsync(async (id, token) => await _userRepository.DoesExistByIdAsync(id))
                .WithMessage("کاربر یافت نشد").WithErrorCode("404");
        }
    }
}

using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Users.Commands.Login
{
    public class LoginUserCommand : IRequest<ErrorOr<string>>
    {
        public LoginUserDto Login { get; set; }
    }

    class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ErrorOr<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ICacheService _cacheService;

        public LoginUserCommandHandler(IUserRepository userRepository,
            IJwtTokenService jwtTokenService,
            IPasswordHasher passwordHasher,
            ICacheService cacheService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
            _passwordHasher = passwordHasher;
            _cacheService = cacheService;
        }

        public async Task<ErrorOr<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByUserNameAsync(request.Login.UserName);
            if (user is null)
                return Error.Validation(description: "نام کاربری یا کلمه عبور اشتباه است");

            if (!_passwordHasher.VerifyPassword(request.Login.Password, user.Password))
                return Error.Validation(description: "نام کاربری یا کلمه عبور اشتباه است");

            string? userSecretCode = await _cacheService.GetUserSecretCodeAsync(user.Id);
            if (userSecretCode is null)
            {
                userSecretCode = Guid.NewGuid().ToString();
                await _cacheService.SaveUserSecretCodeAsync(user.Id, userSecretCode);
            }

            var token = _jwtTokenService.GenerateToken(user, userSecretCode);
            return token;
        }
    }
}

using Shop.Application.Contracts.Persistence;
using Shop.Application.Features.Users.Queries.GetById;
using Shop.Application.Security;

namespace Shop.Application.Features.Users.Commands.Create
{
    public class RegisterUserCommand : IRequest<ErrorOr<ShowUserDto>>
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }

    class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<ShowUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.RegisterUserDto);
            user.Salt = _passwordHasher.GenerateSalt();
            user.Password = _passwordHasher.HashPassword(request.RegisterUserDto.Password, user.Salt);
            user.IsAdmin = false;

            await _userRepository.AddAsync(user);

            try
            {
                await _userRepository.SaveChangesAsync();
                return _mapper.Map<ShowUserDto>(user);
            }
            catch (Exception)
            {
                return Error.Unexpected("خطایی در ثبت اطلاعات رخ داد");
            }
        }
    }
}

using Shop.Application.Contracts.Persistence;
using Shop.Application.Features.Users.Commands.Create;
using Shop.Application.Features.Users.Queries.GetById;
using Shop.Application.Security;

namespace Shop.Application.Features.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<ErrorOr<ShowUserDto>>
    {
        public int Id { get; set; }
        public RegisterUserDto UserDto { get; set; }
    }

    class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, ErrorOr<ShowUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowUserDto>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is null)
                return Error.NotFound($"کاربر با آیدی {request.Id} یافت نشد");

            user.Password = _passwordHasher.HashPassword(request.UserDto.Password, user.Salt);

            _mapper.Map(request.UserDto, user);

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

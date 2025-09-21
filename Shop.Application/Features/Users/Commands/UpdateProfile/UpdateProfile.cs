using Application.Common.Errors;
using Application.Common.Security;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Features.Users.Commands.Create;
using Shop.Application.Features.Users.Queries.GetById;
using Shop.Application.Security;

namespace Shop.Application.Features.Users.Commands.UpdateProfile
{
    public class UpdateProfileCommand : IRequest<ErrorOr<ShowUserDto>>, IRequireOwnership, IRequirePermission
    {
        public int Id { get; set; }
        public RegisterUserDto UserDto { get; set; }
        public string Permission => Permissions.Users.Actions.UpdateName;
        public int ResourceOwnerId => Id;
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
                return Errors.Validation.NotFound("کاربر",  request.Id);

            _mapper.Map(request.UserDto, user);
            user.Password = _passwordHasher.HashPassword(request.UserDto.Password, user.Salt);


            try
            {
                await _userRepository.SaveChangesAsync();
                return _mapper.Map<ShowUserDto>(user);
            }
            catch (Exception)
            {
                return Errors.Validation.Unexpected;
            }
        }
    }
}

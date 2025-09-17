using ErrorOr;
using MapsterMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Features.Users.Queries.GetById;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Users.Commands.Create
{
    public class RegisterUserCommand : IRequest<ErrorOr<ShowUserDto>>
    {
        public RegisterUserDto RegisterUserDto { get; set; }
    }

    class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<ShowUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.RegisterUserDto);
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

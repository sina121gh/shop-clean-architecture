using ErrorOr;
using MapsterMapper;
using MediatR;
using Shop.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.Users.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<ErrorOr<ShowUserDto>>
    {
        public int Id { get; set; }
    }


    class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<ShowUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<ShowUserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return Error.NotFound($"کاربر با آیدی {request.Id} یافت نشد");

            return _mapper.Map<ShowUserDto>(user);
        }
    }
}

using Shop.Application.Contracts.Persistence;
using Shop.Application.Features.Categories.Queries.GetAll;
using Shop.Application.Features.Users.Queries.GetById;

namespace Shop.Application.Features.Users.Queries.GetAll
{
    public class GetAllUsersQuery : IRequest<ErrorOr<PagedResult<ShowUserDto>>>
    {
        public GetAllUsersParameters Parameters { get; set; }
    }

    class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ErrorOr<PagedResult<ShowUserDto>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<PagedResult<ShowUserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.FilterUsersAsync(
                request.Parameters.PageNumber,
                request.Parameters.PageSize, request.Parameters.Query,
                request.Parameters.RoleId, request.Parameters.SortBy,
                request.Parameters.SortDirection);

            return new PagedResult<ShowUserDto>(_mapper.Map<IReadOnlyList<ShowUserDto>>(result.Items),
                result.PageNumber, result.PageSize, result.TotalRecords);
        }
    }
}

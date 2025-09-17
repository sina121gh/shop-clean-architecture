using Shop.Application.Contracts.Persistence;

namespace Shop.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ErrorOr<Unit>>
    {
        public int Id { get; set; }
    }

    class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ErrorOr<Unit>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return Error.NotFound($"کاربر با آیدی {request.Id} یافت نشد");

            _userRepository.Delete(user);

            try
            {
                await _userRepository.SaveChangesAsync();
                return Unit.Value;
            }
            catch (Exception)
            {
                return Error.Unexpected("خطایی در ثبت اطلاعات رخ داد");
            }
        }
    }
}

using Shop.Application.Contracts.Persistence.Common;
using Shop.Application.Enums;

namespace Shop.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        Task<PagedResult<User>> FilterUsersAsync(int pageNumber, int pageSize,
            string? query, bool? isAdmin, string? sortBy, SortDirection sortDirection);

        Task<User?> GetByUserNameAsync(string userName);

        Task<bool> DoesUserNameExistAsync(string userName);
        Task<bool> DoesEmailExistAsync(string email);
    }
}

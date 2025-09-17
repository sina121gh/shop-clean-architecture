using Shop.Application.Contracts.Persistence.Common;
using Shop.Application.Enums;

namespace Shop.Application.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<PagedResult<Category>> FilterCategoriesAsync(int pageNumber, int pageSize,
            string? query, string? sortBy, SortDirection sortDirection);
    }
}

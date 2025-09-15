using Shop.Application.Contracts.Persistence.Common;
using Shop.Application.DTOs;
using Shop.Application.Enums;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<PagedResult<Category>> FilterCategoriesAsync(int pageNumber, int pageSize,
            string? query, string? sortBy, SortDirection sortDirection);
    }
}

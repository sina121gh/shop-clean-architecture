using Shop.Application.Contracts.Persistence.Common;
using Shop.Application.DTOs;
using Shop.Application.Enums;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        Task<PagedResult<User>> FilterUsersAsync(int pageNumber, int pageSize,
            string? query, bool? isAdmin, string? sortBy, SortDirection sortDirection);
    }
}

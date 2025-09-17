using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Application.DTOs;
using Shop.Application.Enums;
using Shop.Domain.Entities;
using Shop.Persistence.Context;
using Shop.Persistence.Extensions;
using Shop.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ShopDbContext _context;

        public UserRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedResult<User>> FilterUsersAsync(int pageNumber, int pageSize,
            string? query, bool? isAdmin, string? sortBy, SortDirection sortDirection)
        {
            var users = _context.Users.AsQueryable();

            if (isAdmin != null)
                users = users.Where(u => u.IsAdmin == isAdmin);

            users = ApplySearch(users, query);

            if (!string.IsNullOrEmpty(sortBy))
                users = users.Sort(sortBy, sortDirection);

            return await users.ToPaginatedResultAsync(pageNumber, pageSize);
        }

        private IQueryable<User> ApplySearch(IQueryable<User> users, string? query)
        {
            return users.Where(u => EF.Functions.Like(u.UserName, $"%{query}%")
                || EF.Functions.Like(u.Email, $"%{query}%"));
        }
    }
}

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

        public async Task<bool> DoesEmailExistAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> DoesEmailExistAsync(string email, int excludingId)
        {
            return await _context.Users
                .Where(u => u.Id != excludingId)
                .AnyAsync(u => u.Email == email);
        }

        public async Task<bool> DoesUserNameExistAsync(string userName)
        {
            return await _context.Users
                .AnyAsync(u => u.UserName == userName);
        }

        public async Task<bool> DoesUserNameExistAsync(string userName, int excludingId)
        {
            return await _context.Users
                .Where(u => u.Id != excludingId)
                .AnyAsync(u => u.UserName == userName);
        }

        public async Task<PagedResult<User>> FilterUsersAsync(int pageNumber, int pageSize,
            string? query, int? roleId, string? sortBy, SortDirection sortDirection)
        {
            var users = _context.Users.AsQueryable();

            if (roleId != null)
                users = users.Where(u => u.RoleId == roleId);

            users = ApplySearch(users, query);

            if (!string.IsNullOrEmpty(sortBy))
                users = users.Sort(sortBy, sortDirection);

            return await users.ToPaginatedResultAsync(pageNumber, pageSize);
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                   .SingleOrDefaultAsync(u => u.UserName == userName);
        }

        private IQueryable<User> ApplySearch(IQueryable<User> users, string? query)
        {
            return users.Where(u => EF.Functions.Like(u.UserName, $"%{query}%")
                || EF.Functions.Like(u.Email, $"%{query}%"));
        }
    }
}

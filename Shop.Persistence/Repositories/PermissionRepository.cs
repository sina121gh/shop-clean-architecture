using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        private readonly ShopDbContext _context;

        public PermissionRepository(ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> DoesUserHavePermissionAsync(int userId ,int permissionId)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Role.RolePermissions)
                .AnyAsync(rp => rp.Permission.Id == permissionId);
        }

        public async Task<bool> DoesUserHavePermissionAsync(int userId, string permission)
        {
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Role.RolePermissions)
                .AnyAsync(rp => rp.Permission.Title == permission);
        }
    }
}

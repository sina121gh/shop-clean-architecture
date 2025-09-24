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
            var parentId = await GetParentPermissionIdAsync(permissionId);
            return await _context.Users
                .Where(u => u.Id == userId)
                .SelectMany(u => u.Role.RolePermissions)
                .AnyAsync(rp => rp.Permission.Id == permissionId
                || rp.PermissionId == parentId);
        }

        public async Task<int?> GetIdByPermissionNameAsync(string permission)
        {
            var perm = await _context.Permissions
                .SingleOrDefaultAsync(p => p.Title == permission);
            return perm?.Id;
        }

        public async Task<int?> GetParentPermissionIdAsync(int permissionId)
        {
            var perm = await _context.Permissions
                .FindAsync(permissionId);
            return perm?.ParentId;
        }

        public async Task<IEnumerable<int>> GetPermissionsIdsOfRoleAsync(int roleId)
        {
            var permissionsIds = await _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.PermissionId)
                .ToListAsync();

            permissionsIds.AddRange(
                await _context.Permissions
                .Where(p => permissionsIds.Contains(p.ParentId.Value))
                .Select(p => p.Id)
                .ToListAsync());

            return permissionsIds;
        }
    }
}

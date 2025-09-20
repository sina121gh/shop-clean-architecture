using Microsoft.EntityFrameworkCore;
using Shop.Application.Contracts.Persistence;
using Shop.Domain.Entities;
using Shop.Persistence.Context;
using Shop.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        private readonly ShopDbContext _context;
        private readonly IRoleRepository _roleRepository;

        public PermissionRepository(ShopDbContext context) : base(context)
        {
            
        }

        public async Task<bool> DoesUserHavePermissionAsync(int userId ,int permissionId)
        {
            var userRoleId = await _roleRepository.GetRoleByUserIdAsync(userId);
            return await _context.RolePermissions
                .AnyAsync(rp => rp.RoleId == userRoleId
                && rp.PermissionId == permissionId);
        }
    }
}

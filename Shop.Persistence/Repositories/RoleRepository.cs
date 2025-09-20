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
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ShopDbContext _context;

        public RoleRepository(ShopDbContext context) : base(context)
        {

        }

        public async Task<int> GetRoleByUserIdAsync(int userId)
        {
            return await _context.Users
                .SingleOrDefaultAsync(u => u.Id == userId)
                .ContinueWith(x => x.Result.RoleId);
        }
    }
}

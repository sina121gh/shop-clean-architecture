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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ShopDbContext _context;

        public UserRepository(ShopDbContext context) : base(context)
        {
            _context = context
        }
    }
}

using Shop.Application.Contracts.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<int?> GetRoleByUserIdAsync(int userId);
    }
}

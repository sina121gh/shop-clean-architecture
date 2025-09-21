using Shop.Application.Contracts.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Persistence
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<bool> DoesUserHavePermissionAsync(int userId, int permissionId);

        Task<int?> GetIdByPermissionNameAsync(string permission);

        Task<int?> GetParentPermissionIdAsync(int permissionId);
    }
}

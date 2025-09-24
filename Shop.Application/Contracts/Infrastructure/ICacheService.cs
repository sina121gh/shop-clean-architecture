using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Contracts.Infrastructure
{
    public interface ICacheService
    {
        Task<bool> DoesKeyExistAsync(string key);

        Task<string?> GetStringAsync(string key);

        Task<bool> RemoveKeyAsync(string key);

        Task<bool> SetStringAsync(string key, string value, TimeSpan? expiration = null);

        #region User Secret Code

        Task<bool> SetUserSecretCodeAsync(int userId, string secretKey);

        Task<string?> GetUserSecretCodeAsync(int userId);

        Task<bool> RemoveUserSecretCodeAsync(int userId);

        Task RemoveAllUserRolesByRoleIdAsync(int roleId);

        Task<IEnumerable<string>> GetAllUserdIdsByRoleIdAsync(int roleId);

        #endregion

        #region Role

        Task<bool> SetRolePermissionsAsync(int roleId, string permissions);

        Task<bool> RemoveRolePermissionsAsync(int roleId);

        Task<string> GetRolePermissionsAsync(int roleId);

        Task<string> GetUserRoleAsync(int userId);

        Task<bool> SetUserRoleAsync(int userId, int roleId);

        Task<bool> RemoveUserRoleAsync(int userId);

        #endregion
    }
}

using Shop.Application.Contracts.Infrastructure;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services
{
    public class RedisService : ICacheService
    {

        #region Ctor

        private readonly IDatabase _redis;

        public RedisService(IDatabase redis)
        {
            _redis = redis;
        }

        #endregion

        public async Task<bool> DoesKeyExistAsync(string key)
        {
            return await _redis.KeyExistsAsync(key);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await _redis.StringGetAsync(key);
        }

        public async Task<bool> RemoveKeyAsync(string key)
        {
            return await _redis.KeyDeleteAsync(key);
        }

        public async Task<bool> SetStringAsync(string key, string value, TimeSpan? expiration = null)
        {
            return await _redis.StringSetAsync(key, value, expiry: expiration);
        }

        public async Task<bool> SaveUserSecretCodeAsync(int userId, string secretKey)
        {
            return await SetStringAsync($"UserSecretCode:{userId}", secretKey, TimeSpan.FromDays(365));
        }

        public async Task<string> GetUserSecretCodeAsync(int userId)
        {
            return await GetStringAsync($"UserSecretCode:{userId}");
        }

        public async Task<bool> RemoveUserSecretCodeAsync(int userId)
        {
            return await RemoveKeyAsync($"UserSecretCode:{userId}");
        }

        public async Task<bool> CacheRolePermissionsAsync(int roleId, string permissions)
        {
            return await SetStringAsync($"RolePermissions:{roleId}", permissions);
        }

        public async Task<bool> RemoveRolePermissionsAsync(int roleId)
        {
            return await RemoveKeyAsync($"RolePermissions:{roleId}");
        }

        public async Task<string> GetRolePermissionsAsync(int roleId)
        {
            return await GetStringAsync($"RolePermissions:{roleId}");
        }

        public async Task RemoveAllUserRolesByRoleIdAsync(int roleId)
        {
            var server = _redis.Multiplexer.GetServer(_redis.Multiplexer.GetEndPoints()[0]);
            var keys = server.Keys(pattern: "UserRole:*").ToList();
            foreach (var key in keys)
            {
                var value = await GetStringAsync(key);
                if (value == roleId.ToString())
                    await _redis.KeyDeleteAsync(key);
            }
        }

        public async Task<string> GetUserRoleAsync(int userId)
        {
            return await GetStringAsync($"UserRole:{userId}");
        }

        public async Task<bool> CacheUserRoleAsync(int userId, int roleId)
        {
            return await SetStringAsync($"UserRole:{userId}", roleId.ToString());
        }

        public async Task<bool> RemoveUserRoleAsync(int userId)
        {
            return await RemoveKeyAsync($"UserRole:{userId}");
        }

        public async Task<IEnumerable<string>> GetAllUserdIdsByRoleIdAsync(int roleId)
        {
            List<string> userIds = new();
            string test;
            var server = _redis.Multiplexer.GetServer(_redis.Multiplexer.GetEndPoints()[0]);
            var keys = server.Keys(pattern: "UserRole:*").ToList();
            foreach (var key in keys)
            {
                var value = await GetStringAsync(key);
                if (value == roleId.ToString())
                    userIds.Add(key.ToString().Remove(0, 9));
            }

            return userIds;
        }
    }
}

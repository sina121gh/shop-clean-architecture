using Application.Common.Security;
using Microsoft.AspNetCore.Http;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Security
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPermissionRepository _permissionRepository;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
            IPermissionRepository permissionRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _permissionRepository = permissionRepository;
        }

        public int? UserId =>
        int.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId)
            ? userId
            : null;

        public string? UserName =>
        _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

        public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public async Task<bool> HasPermissionAsync(string permissionName)
        {
            if (UserId is null) return false;

            if (!PermissionDictionary.NameToId.TryGetValue(permissionName, out var permissionId))
                return false;

            return await _permissionRepository.DoesUserHavePermissionAsync(UserId.Value, permissionId);

        }

        public async Task<bool> HasPermissionAsync(int permissionId)
        {
            if (UserId is null) return false;

            return await _permissionRepository.DoesUserHavePermissionAsync(UserId.Value, permissionId);
        }
    }
}
